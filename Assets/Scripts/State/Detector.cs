using UnityEngine;
using Collider = UnityEngine.Collider2D;
using Collision = UnityEngine.Collision;

public class Detector : IStateHandler<Collision>
{
    public Detector(Collider collider)
    {
        Collider = collider;
    }

    public Collision collision;

    public float Width => Collider.bounds.size.x;
    public float Height => Collider.bounds.size.y;

    public Vector2 Size => Collider.bounds.size;
    public Rect Bounds => new(Collider.transform.position, Collider.bounds.size);

    public Collider Collider { get; }
    public Collision Handle
    {
        get
        {
            return collision;
        }

        set
        {
            if (value.collider == Collider)
            {

            }
            collision = value;
        }
    }
}
