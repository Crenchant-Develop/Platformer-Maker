using System;

public interface IStateConnectable<in T, out StateT>
where StateT : class, IStatable<T>
{
    public StateT State { get; }

    public virtual T OnHandle
    {
        set
        {
            State.OnHandle(value);
        }
    }
}

public interface IStateConnectable<T> : IStateConnectable<T, IStatable<T>>
{
}