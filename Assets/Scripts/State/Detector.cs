using UnityEngine;
using Collider = UnityEngine.Collider2D;
using Collision = UnityEngine.Collision;

//? 확인함.
//? 질문 : 2개
//? 확인 필요 : 0개

//* 상태를 감지하는 역할을 하는 스크립트.
public class Detector : IStateHandler<Collision>
{
    // 콜리전 관련 변수.
    public Collision collision;

    // Collider 프로퍼티에 콜라이더 값을 넣어주는 메서드.
    public Detector(Collider collider)
    {
        Collider = collider;
    }

    // 콜라이더의 가로 세로 길이를 각각 반환하는 메서드.
    public float Width => Collider.bounds.size.x;
    public float Height => Collider.bounds.size.y;

    // 현재 콜라이더의 사이즈를 반환하는 메서드.
    public Vector2 Size => Collider.bounds.size;

    //! 질문 : 프로퍼티에 리턴만 있으면 getter과 setter 중에서 어느 것과
    //!       연관이 있다고 봐야 하나요?
    public Rect Bounds => new(Collider.transform.position, Collider.bounds.size);

    //! 질문 : 이 프로퍼티가 어떤 역할을 하는지 잘 모르겠습니다.
    public Collision Handle
    {
        get
        {
            return collision;
        }

        set
        {
            if (value.collider == Collider)
            {

            }
            collision = value;
        }
    }

    // 콜라이더를 다른 클래스에서 사용할 떄 사용하는 프로퍼티.
    public Collider Collider { get; }
}
