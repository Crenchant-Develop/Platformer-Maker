using System.Runtime.CompilerServices;
using UnityEngine;
using Vector = UnityEngine.Vector2;

public interface IMotionable : IStateHandler<(float speed, Vector direction)>
{
    public float Speed { get => Handle.speed; }
    public Vector Direction { get => Handle.direction; }
}


interface IVellocity
{
    public Vector Velocity { get; }
}

