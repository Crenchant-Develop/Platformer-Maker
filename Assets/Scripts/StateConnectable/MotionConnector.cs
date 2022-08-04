using UnityEngine;
using Vector = UnityEngine.Vector2;

public class MotionConnector : MonoBehaviour, IMotionConnectable
{
    public MotionConnector()
    {
        MotionConnectable = this;
    }

    IMotionConnectable MotionConnectable { get; }

    [field: SerializeField]
    public virtual Component Component { get; set; }

    public MotionalState State { get; set; }
    public (float speed, Vector direction) Handle { get => State.Handle; set => State.Handle = value; }

    protected virtual void Awake()
    {
        MotionConnectable.Join = Component;
    }
}