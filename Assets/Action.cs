using UnityEngine;


interface IController<StateType>
{
    StateType State { get; set; }
}

interface IAction
{
    void Invoke<T, State>(T controller) where T : IController<State>;
}


interface IAction<StateType> : IAction
{
    void Invoke<T>(T controller) where T : IController<StateType> 
    {
        Invoke<T, StateType>(controller);
    }
}

class Jump : IAction
{
    public void Invoke<T1, T2>(T1 controller) where T1 : IController<T2>
    {
    }

    public void Invoke<T>(T controller) where T: IController<Vector2>
    {
    }
}

class Move : IAction
{
    public void Invoke<T, State>(T controller) where T : IController<State>
    {
    }
}
