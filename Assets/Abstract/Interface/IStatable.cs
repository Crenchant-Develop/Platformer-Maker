using System;

//IControllable에서 전달해주는 value값을 Handle에 가지게 할 것이다.
//Handle값이 바뀌면 상태가 바뀐 것이므로 IActionable
public interface IStatable<out T>
{
    T Handle { get; }
}
