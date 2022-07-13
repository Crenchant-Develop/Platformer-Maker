using UnityEngine;

public abstract class StatableObject : IStatable<string>
{
    public string Name { get; }

    string IStatable<string>.Handle => Name;

    public (IC, IA) Bind<T, IC, IA>(out IC controllable, out IA actionable)
    where T : StatableObject
    where IC : class, IControllable<T>, new()
    where IA : class, IActionable<T>, new()
    {
        T statableObject = this as T;
        controllable = new();
        actionable = new();
        controllable.State = statableObject;
        actionable.State = statableObject;

        return (controllable, actionable);
    }

    public StatableObject(string name)
    {
        Name = name;
    }
}
