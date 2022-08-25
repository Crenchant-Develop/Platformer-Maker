using System.Collections.Generic;
using UnityEngine;
using Rigidbody = UnityEngine.Rigidbody2D;
using ContactPoint = UnityEngine.ContactPoint2D;

[DisallowMultipleComponent]
public class Movement : MotionConnector, IActionable<MotionalState>
{
    bool isGround;

    [field: SerializeField]
    public float JumpPower { get; set; }

    [field: SerializeField]
    public override MotionalState State { get; set; }

    [field: SerializeField]
    public Detector Detector { get; set; }

    public Vector2 Range { get; private set; }


    public Rigidbody Rigidbody { get; set; }

    void OnWalk()
    {
        Rigidbody.velocity = new (State.Horizontal, Rigidbody.velocity.y);
    }

    void OnJump()
    {
        if (isGround && State.Direction.y > 0f)
        {
            isGround = false;
            Rigidbody.AddForce(JumpPower * State.Direction * Vector2.up, ForceMode2D.Impulse);
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