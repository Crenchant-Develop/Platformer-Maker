﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public interface IStateConnectable<T>
where T : class, new()
{
    public T State { get; set; }

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
}