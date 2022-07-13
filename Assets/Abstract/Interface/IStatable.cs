using System.Collections.Generic;
using System;


//IControllable에서 전달해주는 value값을 Handle에 가지게 할 것이다.
//Handle값이 바뀌면 상태가 바뀐 것이므로 IActionable
//이거만 상속받으면 Handle을 Getter로만 사용가능함

public interface IStatable
{
    object Handle { get; }
}

public interface IStatable<out T> : IStatable
{
    new T Handle { get; }
}

