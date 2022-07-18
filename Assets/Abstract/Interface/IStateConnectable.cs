using System;

public interface IStateConnectable<T>
{
    public IStateConnectable<T> State { get; set; }
    public T Handle { get => State.Handle; set => State.Handle = value; }
}

public static class StateConnectableExtender
{
    public static S CreateConnect<T, S>(this IStateConnectable<T> connectable)
    where S : class, IStateConnectable<T>, new()
    {
        S connectTarget = new()
        {
            State = connectable
        };
        connectable.State = connectTarget;
        return connectTarget;
    }

    public static IA CreateConnectedControllable<T, IA>(this IControllable<T> controllable)
    where IA : class, IActionable<T>, new()
    {
        return controllable.CreateConnect<T, IA>();
    }

    public static IC CreateConnectedActionable<T, IC>(this IActionable<T> actionable)
    where IC : class, IControllable<T>, new()
    {
        return actionable.CreateConnect<T, IC>();
    }

    public static void CreateConnect<T, IC, IA>(out IC controllable, out IA actionable)
    where IC : class, IControllable<T>, new()
    where IA : class, IActionable<T>, new()
    {
        controllable = new();
        actionable = new();
        controllable.State = actionable;
        actionable.State = controllable;
    }
}