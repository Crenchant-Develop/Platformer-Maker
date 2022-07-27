using System;
using System.Runtime.CompilerServices;

public interface IStateHandler<T>
where T : new()
{
    T Handle { get; set; }
}
