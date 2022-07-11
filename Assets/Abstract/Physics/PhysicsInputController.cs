using System;

// 움직일 수 있는 객체의 조작 인풋 인식에 관여하는 클래스.
// 추상화 클래스가 아니므로 상속 받은 인터페이스 IControllable의
// 추상화된 내용들을 채워주어야 함.
public class PhysicsInputController : IControllable<PhysicsState>
{
    // 객체의 상태를 담아주는 자동 구현 프로퍼티.
    // (예 : 물리적인 행동을 하는 상태, 가만히 있는 상태 등)
    public PhysicsState State { get; set; }
    PhysicsState IStatable<PhysicsState>.Handle => State;

    //! 질문 : 아래처럼 설명 쓰는게 맞을까요?
    //! 객체의 상태를 업데이트 해주는 메서드.
    void OnStateUpdate() 
    {
        //State = value;
    }
}