using System.Collections.Generic;
using System;

//행동이 가능한 객체의 일반화와 다형성을 위해 정의해놓은 추상 타입.
//예를들어 공격, 구르기, 점프, 이동 같은 클래스 타입에 상속받을 예정
public interface IActionable<T> : IStatable<T> where T : class, IStatable<object>
{
    public T State { get; set; }

    //호출하면 그 행동을 한다.
    public void Invoke();
}

