using UnityEngine;
//나중에 2D에서 3D로 마이그레이션을 쉽게 할 수 있도록 아래처럼 적었음
using Rigidbody = UnityEngine.Rigidbody2D;
using Vector = UnityEngine.Vector3;

//물리적인 어떠한 값이나 상태를 레퍼런스로서 공유하기 위해 만듬.
public class PhysicsState : StatableObject, IStatable<Rigidbody>, IStatable<Transform>, IStatable<Vector>, IStatable<float>
{
    public Transform Transform { get; }
    public Rigidbody Rigidbody { get; }
    public float Speed { get; set; } = 1f;
    public Vector Direction { get; set; }

    Transform IStatable<Transform>.Handle => Transform;
    Rigidbody IStatable<Rigidbody>.Handle => Rigidbody;
    Vector IStatable<Vector>.Handle => Direction;
    float IStatable<float>.Handle => Speed;

    public PhysicsState(Transform transform = null) : base(transform.name)
    {
        Transform = transform??GameObject.Find(Name).transform;
        Rigidbody = transform.GetComponent<Rigidbody>();
        Direction = default;
        Speed = default;

        // 이 코드도 이해는 안되겠지만
        // 상태객체를 등록해주는 코드입니다..
        Transform.AddState(this);
    }
}


