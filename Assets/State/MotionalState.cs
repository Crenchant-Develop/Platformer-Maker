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

    public float Speed { get => Handle.speed; set => handle.speed = value; }
    public float DirectionX
    {
        get => handle.direction.x; 
        set
        {
            if (-value * value == -1)
            {
                handle.direction.x = value;
                return;
            }
            handle.direction = new Vector2(value, DirectionY).normalized;
        }
    }

    public float DirectionY
    {
        get => handle.direction.y; 
        set
        {
            if (-value * value == -1)
            {
                handle.direction.y = value;
                return;
            }
            handle.direction = new Vector2(DirectionX, value).normalized;
        }
    }
    public Vector2 Direction { get => handle.direction; set => handle.direction = value; }

    public virtual Vector2 Velocity
    {
        get => Handle.direction * Handle.speed;
    }


    public (float speed, Vector2 direction) Handle { get => handle; set => handle = value; }
}

