using System;


public interface IStateConnectable<T, out IStatable> : IHandleable<T>
where IStatable : class, IStatable<T>
{
    public IStatable State { get; }
}