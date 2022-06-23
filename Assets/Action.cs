using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <State>�� Generic�̴�.
interface IController<State>
{
    State state { get; set; }
}

interface IAction
{
    void Invoke<T, State>(T controller) where T: IController<State>;
}

class Jump : IAction
{
    public void Invoke<T, State>(T controller) where T : IController<State>
    {
    }
}

class Move : IAction
{
    public void Invoke<T, State>(T controller) where T : IController<State>
    {
    }
}


