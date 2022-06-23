using UnityEngine;

class PlayerController : IController<Vector2>
{
    Vector2 IController<Vector2>.State { set; }

    public Vector2 State { get; set; }
}
