using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DirectionController : MotionConnector, IControllable<MotionalState>
{
    private void OnRandom(Action invert)
    {
        const int min = 0;
        const int max = 1;
        const int apply = max + 1;

        //방향 랜덤하게 반전함
        if (invert == InvertHorizontal || invert == InvertVertical)
        {
            if (Random.Range(min, apply) is max)
            {
                invert();
            }
            return;
        }
        Debug.LogError($"잘못된 대리자 {nameof(invert)}의 값입니다. \n" +
            $"{nameof(InvertHorizontal)}이나 {nameof(InvertVertical)}로 지정해주세요. 현재 invert의 값: {invert}");
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