using System.Runtime.CompilerServices;
using UnityEngine;


public interface IMotionable : IStateHandler<(float speed, Vector2 direction)>, ITuple
{
    int ITuple.Length => ((ITuple)Handle).Length;
    object ITuple.this[int index] => ((ITuple)Handle)[index];

    public float Speed { get => Handle.speed; }
    public Vector2 Direction { get => Handle.direction; }
}


interface IVellocity
{
    public Vector2 Velocity { get; }
}

