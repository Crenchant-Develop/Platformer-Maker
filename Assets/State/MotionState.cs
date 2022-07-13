using UnityEngine;
using Rigidbody = UnityEngine.Rigidbody2D;
using Vector = UnityEngine.Vector3;

public class MotionState : IStatable<Transform>, IStatable<Rigidbody>, IStatable<Vector>, IStatable<float>
{
    public MotionState(Transform transform)
    {
        Transform = transform;
        Rigidbody = transform.GetComponent<Rigidbody>();
    }

    public Transform Transform { get; }
    public Rigidbody Rigidbody { get; }
    public Vector Direction { get => Rigidbody.velocity.normalized; }
    public float Speed { get => Rigidbody.velocity.magnitude; set => Rigidbody.velocity = Direction * value; }

    object IStatable.Handle => Transform.gameObject;
    Transform IStatable<Transform>.Handle { get => Transform; }
    Rigidbody IStatable<Rigidbody>.Handle { get => Rigidbody; }
    Vector IStatable<Vector>.Handle { get => Direction; }
    float IStatable<float>.Handle { get => Speed; }

    public static implicit operator Transform(MotionState value)
    {
        return value.Transform;
    }
    public static implicit operator Rigidbody(MotionState value)
    {
        return value.Rigidbody;
    }
    public static implicit operator Vector(MotionState value)
    {
        return value.Direction;
    }
}
