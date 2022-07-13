using UnityEngine;
using Collision = UnityEngine.Collision2D;
using Collider = UnityEngine.Collider2D;

public class CollisonState : IStatable<Collision>, IStatable<Collider>
{
    public Collision Collision { get; set; }
    public Collider Collider { get; set; }

    object IStatable.Handle => this;

    Collision IStatable<Collision>.Handle
    {
        get
        {
            return Collision;
        }
    }

    Collider IStatable<Collider>.Handle => Collider;

    public CollisonState(Transform transform)
    {
        Collider = transform.GetComponent<Collider>();
    }

    public CollisonState(Collider collider)
    {
        Collider = collider;
    }
}
