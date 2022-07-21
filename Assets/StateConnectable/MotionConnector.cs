using UnityEngine;

public class MotionConnector : MonoBehaviour, IMotionConnectable
{
    IMotionConnectable MotionConnectable { get; }

    [field:SerializeField]
    public virtual Component Component { get; set; }

    public Component Join { get => Component; set => MotionConnectable.Join = value; }
    
    public MotionalState State { get; set; }
    public (float speed, Vector2 direction) Handle { get => State.Handle; set => State.Handle = value; }

    public MotionConnector() 
    {
        MotionConnectable = this;
        Join = Component;
    }
}
