using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public interface IStateHandler<T> : ITuple
where T : new()
{
    object ITuple.this[int index] { get => ((ITuple)Handle)[index]; }
    int ITuple.Length { get => ((ITuple)Handle).Length; }

    T Handle { get; set; }
}
