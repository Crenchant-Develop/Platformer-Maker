using Vector = UnityEngine.Vector2;

public interface IMotionable : IStateHandler<(float speed, Vector direction)>
{
    public float Speed { get => Handle.speed; }
    public Vector Direction { get => Handle.direction; }

    public bool IsDefault { get => Speed == default; }
}


interface IVellocity
{
    public Vector Velocity { get; }
}
