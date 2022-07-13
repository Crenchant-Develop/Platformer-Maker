using UnityEngine;
using Collision = UnityEngine.Collision2D;

public class CollisonController : MonoBehaviour, IControllable<CollisonState>
{
    public CollisonState State { get; }

    private void OnCollisionEnter2D(Collision collision)
    {
        State.Collision = collision;
    }
}