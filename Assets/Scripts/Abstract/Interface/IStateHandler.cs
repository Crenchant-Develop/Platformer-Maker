using System;
using System.Runtime.CompilerServices;

public interface IStateHandler<T> : IEquatable<T>
where T : new()
{
    T Handle { get; set; }

    bool IEquatable<T>.Equals(T other)
    {
        return Handle.Equals(other);
    }
}
