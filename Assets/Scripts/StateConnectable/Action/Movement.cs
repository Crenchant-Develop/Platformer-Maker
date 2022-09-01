using System.Collections.Generic;
using UnityEngine;
using Rigidbody = UnityEngine.Rigidbody2D;
using ContactPoint = UnityEngine.ContactPoint2D;

[DisallowMultipleComponent]
public class Movement : MotionConnector, IActionable<MotionalState>
{
    bool isGround;

    [field: SerializeField]
    public float JumpForce { get; set; }

    [field: SerializeField]
    public override MotionalState State { get; set; }

    [field: SerializeField]
    public Detector Detector { get; set; }

    public Rigidbody Rigidbody { get; set; }

    void OnWalk()
    {
        if (State.Direction == Vector2.zero)
        {
            return;
        }

        Rigidbody.velocity = new (State.Horizontal, Rigidbody.velocity.y);
    }

    void OnJump()
    {
        if (State.Direction.y > 0f && isGround)
        {
            isGround = false;
            Rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            return;
        }
    }

    void OnDetect(ContactPoint contact) 
    {
        isGround = contact.normal.y < 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Detector.Handle = collision.collider;
    }

    protected override void Awake()
    {
        base.Awake();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        OnJump();
        OnWalk();
    }

    public Movement() 
    {
        Detector = new(OnDetect);
    }
}