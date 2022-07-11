using System.Collections.Generic;
using System;

// 움직임 등의 행동을 포함하는 객체의 일반화와 다형성을 위해 정의한 추상 타입의 인터페이스.
// 여러 클래스 타입에 상속될 예정. (예 : 공격, 구르기, 점프, 이동 등)\
//! 질문 : where T의 역할이 궁금합니다.
//! 질문 : IStable<object> 에서 object가 데이터형인가요?
public interface IActionable<T> : IStatable<T> where T : class, IStatable<object>
{
    // Generic 타입의 자동 구현 프로퍼티.
    public T State { get; set; }

    // 메서드의 내용은 상속받는 클래스에서 채워줌.
    public void Invoke();
}