using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public interface IStateConnectable<T>
where T : class, new()
{
    public T State { get; set; }

    //이 프로퍼티 메소드는 대부분 Awake나 Init메소드 또는 생성자같은 곳에서 호출한다.
    public Component Join
    {
        set
        {
            var stateHandler = CastToState(value);
            if (stateHandler.State is null)
            {
                State = new T();
                stateHandler.State = State;
                return;
            }

            State = stateHandler.State;
        }
    }
    public S CastToState<S>(Component from)
    where S : class, IStateConnectable<T>, new()
    {
        S stateConnectable = from as S ?? from.GetComponent<S>();
        return stateConnectable;
    }

    public IStateConnectable<T> CastToState(Component from)
    {
        return from.CastToState<T>();
    }
}

public static class StateExtender
{
    public static IStateConnectable<T> CastToState<T>(this Component from)
    where T : class, new()
    {
        var stateConnectable =
            from as IStateConnectable<T> ??
            from.GetComponent<IStateConnectable<T>>();
        return stateConnectable;
    }

    public static IStateConnectable<T> CastToState<T>(this UnityEngine.Object from)
    where T : class, new()
    {
        var stateConnectable =
            (from as IStateConnectable<T>) ??
            (from as Component).GetComponent<IStateConnectable<T>>();
        return stateConnectable;
    }

    public static S CastToState<T, S>(this Component from)
    where S : class, IStateConnectable<T>, new()
    where T : class, new()
    {
        S stateConnectable = from as S ?? from.GetComponent<S>();
        return stateConnectable;
    }
}