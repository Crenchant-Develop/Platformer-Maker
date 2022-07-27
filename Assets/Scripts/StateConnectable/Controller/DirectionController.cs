using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DirectionController : MotionConnector, IControllable<MotionalState>
{
    [SerializeField]
    float speed;

    public float X { get => State.DirectionX; set => State.DirectionX = value; }
    public float Y { get => State.DirectionY; set => State.DirectionY = value; }


    public void OnRandom()
    {
        const int min = 0;
        const int max = 1;
        const int apply = max + 1;
        //방향 랜덤하게 결정됨
        X = Random.Range(min, apply) > 0 ? -1f : 1f;
    }

    public void Invert() 
    {
        X = -X;
    }

    protected override void Awake()
    {
        base.Awake();
        OnRandom();
        State.Speed = speed;
    }
}
