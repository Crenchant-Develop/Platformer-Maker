using System;

//! 질문 : 아래처럼 설명 쓰는게 맞을까요?
//! IControllable 인터페이스를 통해 전달받은 T 타입의 값을 T타입인 Handle 프로퍼티에 전달해줌.
// Handle로 받는 값이 바뀔 경우 상태가 바뀐 것으로 간주하고 IActionable을 호출함.
public interface IStatable<out T>
{
    T Handle { get; }
}
