using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Physics2D;

public class DirectionController : MotionConnector, IControllable<MotionalState>
{
    [SerializeField]
    float speed;
    [SerializeField]
    private bool isRandom = false;
    [SerializeField]
    private List<LayerMask> detectableLayerMasks = new();

    public float X { get => State.DirectionX; set => State.DirectionX = value; }
    public float Y { get => State.DirectionY; set => State.DirectionY = value; }

    public bool IsWall 
    {
        get
        {
            return Raycast(transform.position, State.Direction, State.Speed, detectableLayerMasks[0]);
        }
    }

    public void OnRandom()
    {
        const int min = 0;
        const int max = 1;
        const int apply = max + 1;
        //방향 랜덤하게 결정됨
        X = Random.Range(min, apply) > 0 ? -1f : 1f;
    }

    void MergeLayerMask() 
    {
        for (int i = 0; i < detectableLayerMasks.Count; i++)
        {
            detectableLayerMasks[0] += detectableLayerMasks[i];
        }
    }

    protected override void Awake()
    {
        base.Awake();
        MergeLayerMask();
        OnRandom();
        State.Speed = speed;
    }

    private void Update()
    {
        if (isRandom)
        {
            if (IsWall)//벽에 닿을때
            {
                OnRandom();
            }
            return;
        }
    }
}
