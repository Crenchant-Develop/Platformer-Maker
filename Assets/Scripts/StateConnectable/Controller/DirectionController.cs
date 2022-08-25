using UnityEngine;
using Random = UnityEngine.Random;
using ContactPoint = UnityEngine.ContactPoint2D;

public class DirectionController : MotionConnector, IControllable<MotionalState>
{
    public override MotionalState State { get; set; }
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
}
