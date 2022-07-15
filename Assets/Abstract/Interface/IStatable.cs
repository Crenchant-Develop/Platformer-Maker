using System.Collections.Generic;
using System;
using UnityEngine;


//IControllable에서 전달해주는 value값을 Handle에 가지게 할 것이다.
//Handle값이 바뀌면 상태가 바뀐 것이므로 IActionable
//이거만 상속받으면 Handle을 Getter로만 사용가능함
public interface IStatable<T> : IHandleable<T>
{
    T IGetHandleable<T>.Handle { get => StateConnectable.Get.Handle; }
    T ISetHandleable<T>.Handle { set => StateConnectable.Set.Handle = value; }
    public IStateConnectable<T, IStatable<T>> StateConnectable { get; }
}

public interface ISetHandleable<in T>
{
    public abstract T Handle { set; }
}

public interface IGetHandleable<out T>
{
    public abstract T Handle { get; }
}

public interface IHandleable<T> : IGetHandleable<T>, ISetHandleable<T>
{
    abstract T IGetHandleable<T>.Handle { get; }
    abstract T ISetHandleable<T>.Handle { set; }

    public virtual ISetHandleable<T> Set { get => this; }
    public virtual IGetHandleable<T> Get { get => this; }
}