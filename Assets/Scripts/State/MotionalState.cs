using UnityEngine;

//? 확인함.
//? 질문 : 1개
//? 확인 필요 : 1개

//* 현재 동작 상태를 관리하는 스크립트.
public class MotionalState : IMotionable, IVellocity
{
    public float this[int index]
    {
        set 
        {
            handle.direction[index] = value;
        }
    }

    protected (float speed, Vector2 direction) handle;

    // 속도를 가져오거나 담아주는 프로퍼티.
    public float Speed { get => Handle.speed; set => handle.speed = value; }
    
    // X방향과 Y방향을 담아주거나 가져오는 프로퍼티.
    public float DirectionX
    {
        get => handle.direction.x; 
        set
        {
            //! 질문 : value가 양수든 음수든 음수가 나오면 이 if문은 왜 있는건가요?
            //!       if문이 없는 것과 거의 똑같아 보여서요.
            if (-value * value == -1)
            {
                // X 방향을 value로 초기화함.
                handle.direction.x = value;
                return;
            }
            // TODO : 단위 벡터와 정규화 찾아보기
            // 참고 자료 : https://seojingames.tistory.com/entry/%EB%B0%A9%ED%96%A5-%EB%B2%A1%ED%84%B0-%EB%B2%A1%ED%84%B0%EC%9D%98-%EC%A0%95%EA%B7%9C%ED%99%94normalized-%EC%9C%A0%EB%8B%88%ED%8B%B0
            handle.direction = new Vector2(value, DirectionY).normalized;
        }
    }
    public float DirectionY
    {
        get => handle.direction.y; 
        set
        {
            if (-value * value == -1)
            {
                // Y 방향을 value로 초기화함.
                handle.direction.y = value;
                return;
            }
            handle.direction = new Vector2(DirectionX, value).normalized;
        }
    }

    // handle.direction을 가져오거나 담아주는 프로퍼티.
    public Vector2 Direction { get => handle.direction; set => handle.direction = value; }


    // Vector2 타입의 가속도 값을 반환하는 프로퍼티.
    public virtual Vector2 Velocity
    {
        get => Handle.direction * Handle.speed;
    }

    // handle을 가져오거나 담아주는 프로퍼티.
    public (float speed, Vector2 direction) Handle { get => handle; set => handle = value; }
}

