using System;
using UnityEngine;

public class MotionConnector : MonoBehaviour, IMotionConnectable
{
    public MotionConnector()
    {
        MotionConnectable = this;
    }

    IMotionConnectable MotionConnectable { get; }

    [field:SerializeField]
    public virtual Component Component { get; set; }

    public MotionalState State { get; set; }
    public (float speed, Vector2 direction) Handle { get => State.Handle; set => State.Handle = value; }

    protected virtual void Awake()
    {
        MotionConnectable.Join = Component;
    }
}

