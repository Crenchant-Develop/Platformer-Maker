using UnityEngine;

public class DirectionController : MotionConnector, IControllable<MotionalState>
{
    [SerializeField]
    bool isRandom = false;

    public float X { get => State.DirectionX; set => State.DirectionX = value; }
    public float Y { get => State.DirectionY; set => State.DirectionY = value; }

    public void OnRandom()
    {
        const int min = 0;
        const int max = 1;
        const int apply = max + 1;
        if (true)//벽에 닿을때만
        {
            //방향 랜덤하게 결정됨
            X = Random.Range(min, apply) > 0 ? -1f : 1f;
        }
    }

    private void Update()
    {
        if (isRandom)
        {
            OnRandom();
            return;
        }
    }
}