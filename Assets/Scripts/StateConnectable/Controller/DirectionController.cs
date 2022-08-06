using System;
using UnityEngine;
using Random = UnityEngine.Random;
using ContactPoint = UnityEngine.ContactPoint2D;

public class DirectionController : MotionConnector, IControllable<MotionalState>
{
    [field: SerializeField]
    Detector detector = default;

    protected int RandomSide
    {
        get
        {
            const byte min = 0;
            const byte max = 1;
            const byte apply = max + 1;
            return Random.Range(min, apply) is max ? -1 : 1;
        }
    }

    public void OnRandomHorizontal()
    {
        State.Horizontal = RandomSide;
    }

    public void OnRandomVertical()
    {
        State.Vertical = RandomSide;
    }

    public void InvertHorizontal()
    {
        State.Horizontal = -State.Horizontal;
    }

    public void InvertVertical()
    {
        State.Vertical = -State.Vertical;
    }

    public virtual void OnDetectWall(ContactPoint contact) 
    {
        //벽을 감지하면
        bool isWaill = contact.normal.x != 0;
        if (isWaill)
        {
            //반대로 이동.
            InvertHorizontal();
            detector.OnHandleInvoke = null;
            return;
        }
    }

    protected override void Awake()
    {
        base.Awake();

        detector = new Detector
        {
            OnHandleInvoke = OnDetectWall
        };
    }
}

