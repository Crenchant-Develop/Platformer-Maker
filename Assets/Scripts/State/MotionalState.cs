using System.Runtime.CompilerServices;
using UnityEngine;

public class MotionalState : IMotionable, IVellocity
{
    public float this[int index]
    {
        set 
        {
            handle.direction[index] = value;
        }
    }

    protected (float speed, Vector2 direction) handle;
    public (float speed, Vector2 direction) Handle { get => handle; set => handle = value; }

    public virtual Vector2 Velocity
    {
        get => Handle.direction * Handle.speed;
    }
    public float Speed { get => handle.speed; set => handle.speed = value; }
    public Vector2 Direction { get => handle.direction; set => handle.direction = value; }

    public float DirectionX
    {
        get => handle.direction.x;
        set => Normalize(value, ref handle.direction.x);
    }

    public float DirectionY
    {
        get => handle.direction.y;
        set => Normalize(value, ref handle.direction.y);
    }

    public void Normalize(float value, ref float index)
    {
        index =
            value is 0f ? 0f :
            value < 0f ? -1f : 1f;

        if (index is not 0)
        {
            handle.direction.Normalize();
        }
    }
}