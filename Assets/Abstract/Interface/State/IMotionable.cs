using UnityEngine;

public interface IMotionable : IStateHandler<(float speed, Vector2 direction)>
{
    public float Speed { get => Handle.speed; }
    public Vector2 Direction { get => Handle.direction; }
}
interface IVellocity
{
    public Vector2 Velocity { get; }
}

