using System.Collections.Generic;
using UnityEngine;
using Rigidbody = UnityEngine.Rigidbody2D;
using ContactPoint = UnityEngine.ContactPoint2D;

[DisallowMultipleComponent]
public class Movement : MotionConnector, IActionable<MotionalState>
{
    bool isGround;

    [field: SerializeField]
    public float JumpSpeed { get; set; }
    [field: SerializeField]
    public float JumpDistance { get; set; }
    Vector2 lastPosition;
    bool isJumping;

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
        lastPosition = transform.position;
        var value = Rigidbody.velocity;

        //땅이 아닌경우 상승하지않음 (공중에 있는 경우)
        //and
        //지정된 만큼의 점프 높이를 넘기면 상승하지않음 (공중에서 상승중인 경우)
        if (!isGround && transform.position.y - lastPosition.y > JumpDistance)
        {
            print(Mathf.Abs(transform.position.y - lastPosition.y));

            value.y = 0f;
            Rigidbody.velocity = value;
            return;
        }

        //점프키를 누르는 중일때만 상승함
        if (State.Direction.y > 0f || isJumping)
        {
            isJumping = true;
            value.y = JumpSpeed;
            Rigidbody.velocity = value;
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
        lastPosition = transform.position;
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