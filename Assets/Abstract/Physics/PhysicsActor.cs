// 물리적인 행동을 할수 있는 객체의 클래스.

// IActionable 인터페이스를 상속받는 클래스. 이 클래스도 추상 타입의 클래스이므로
// 메서드의 내용은 이 클래스를 상속받는 자식 클래스에서 채워줘야 함.

//! 질문 : 왜 인터페이스로 안하고 추상 클래스로 하셨나요?
public abstract class PhysicsActor : IActionable<PhysicsState>
{
    // 객체의 상태를 담아주는 자동 구현 프로퍼티.
    // (예 : 물리적인 행동을 하는 상태, 가만히 있는 상태 등)
    public PhysicsState State { get; set; }

    //! 질문 : 아래처럼 설명 쓰는게 맞을까요?
    //! PlayState.cs 에서 Handle의 타입과 반환하는 값을 정해줌.
    PhysicsState IStatable<PhysicsState>.Handle => State;

    // 메서드의 내용은 상속받는 클래스에서 채워줌.
    public abstract void Invoke();
}