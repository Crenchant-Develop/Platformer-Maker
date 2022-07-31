using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public interface IStateHandler<T> : ITuple
where T : new()
{
    //ITuple타입을 상속받기 위해 ITuple타입의 멤버를 명시적으로 구현했음.
    object ITuple.this[int index] { get => ((ITuple)Handle)[index]; }
    int ITuple.Length { get => ((ITuple)Handle).Length; }

    T Handle { get; set; }
}
