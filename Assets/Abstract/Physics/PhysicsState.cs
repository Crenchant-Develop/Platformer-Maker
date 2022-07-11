using UnityEngine;

// 나중에 2D 프로젝트에서 3D 프로젝트로 마이크레이션을
// 더 용이하게 할수 있도록 아래와 같이 작성됨.
using Rigidbody = UnityEngine.Rigidbody2D;
using Vector = UnityEngine.Vector3;

// 물리적인 어떠한 값이나 상태를 참조할 대상으로 (레퍼런스로) 공유하기 위해 만듬.
//! 모든 인터페이스를 상속 받고, [내용 추가 예정]

//! 질문 : StableObject의 역할
//! 질문 : 왜 IStatable<Vector> 이랑 IStatable<float>이랑 따로 있는 걸까요?
public class PhysicsState : StatableObject, IStatable<Rigidbody>, IStatable<Transform>, IStatable<Vector>, IStatable<float>
{
    // 상태를 담기 위한 프로퍼티.
    public Transform Transform { get; }
    public Rigidbody Rigidbody { get; }
    public float Speed { get; set; } = 1f;
    public Vector Direction { get; set; }

    //! 질문 : Handle이 어디서 온지 잘 모르겠어요.
    Transform IStatable<Transform>.Handle => Transform;
    Rigidbody IStatable<Rigidbody>.Handle => Rigidbody;
    Vector IStatable<Vector>.Handle => Direction;
    float IStatable<float>.Handle => Speed;

    // 현재 물리 상태를 담아내는 메서드.
    //! 질문 : base(transform.name) 를 상속받고 있는데 이게 어디서 온건가요?
    //!       왜 F12를 누르면 StatableObject 메서드가 나올까요?
    public PhysicsState(Transform transform = null) : base(transform.name)
    {
        Transform = transform??GameObject.Find(Name).transform;
        Rigidbody = transform.GetComponent<Rigidbody>();
        Direction = default;
        Speed = default;

        // 이 코드도 이해는 안되겠지만
        // 상태객체를 등록해주는 코드입니다.
        //! 질문 : 왜 매개변수에 this만 넣어주는데 매개변수가 2개인 메서드가 실행이 되나요?
        Transform.AddState(this);
    }
}


