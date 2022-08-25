using System;
using UnityEngine;
using Vector = UnityEngine.Vector2;

[Serializable]
public class MotionalState : IMotionable, IVellocity
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector direction;

    public float this[int index]
    {
        set
        {
            direction[index] = value;
        }
    }

    public (float speed, Vector direction) Handle
    {
        get => (speed, direction);

        set
        {
            speed = value.speed;
            direction = value.direction;
        }
    }

    public virtual float Speed { get => speed; set => speed = value; }
    public virtual float Horizontal { get => direction.x * speed; set => direction.x = value; }
    public virtual float Vertical { get => direction.y * speed; set => direction.y = value; }
    public virtual Vector Velocity => direction * speed;
    public virtual Vector Direction { get => direction; set => direction = value; }
    
    public bool IsDefault { get => Speed == default; }
}