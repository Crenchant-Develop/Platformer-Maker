using UnityEngine;
using Rigidbody = UnityEngine.Rigidbody2D;

public class Movement : MotionConnector, IActionable<MotionalState>
{
    [field: SerializeField]
    Rigidbody Rigidbody { get; set; }

    public void Update()
    {
        Rigidbody.velocity = State.Velocity;
    }

    protected override void Awake()
    {
        base.Awake();
        Rigidbody = GetComponent<Rigidbody>();
    }
}
