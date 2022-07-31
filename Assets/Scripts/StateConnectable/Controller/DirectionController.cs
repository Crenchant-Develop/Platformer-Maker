using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class DirectionController : MotionConnector, IControllable<MotionalState>
{
    public void OnRandom(Action invert)
    {
        const int min = 0;
        const int max = 1;
        const int apply = max + 1;
        //방향 랜덤하게 결정됨
        if (Random.Range(min, apply) is max)
        {
            invert();
        }
    }

    public void OnRandomHorizontal() 
    {
        OnRandom(InvertHorizontal);
    }
    
    public void OnRandomVertical()
    {
        OnRandom(InvertVertical);
    }

    public void InvertHorizontal()
    {
        State.Horizontal = -State.Horizontal;
    }

    public void InvertVertical()
    {
        State.Vertical = -State.Vertical;
    }

    protected override void Awake()
    {
        base.Awake();
        OnRandom(InvertHorizontal);
    }
}