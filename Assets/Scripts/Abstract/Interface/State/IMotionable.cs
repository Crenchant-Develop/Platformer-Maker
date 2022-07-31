using System.Runtime.CompilerServices;
using UnityEngine;
using Vector = UnityEngine.Vector2;

public interface IMotionable : IStateHandler<(float speed, Vector direction)>, ITuple
{
    int ITuple.Length => ((ITuple)Handle).Length;
    object ITuple.this[int index] => ((ITuple)Handle)[index];

    public float Speed { get => Handle.speed; }
    public Vector Direction { get => Handle.direction; }
}


interface IVellocity
{
    public Vector Velocity { get; }
}

