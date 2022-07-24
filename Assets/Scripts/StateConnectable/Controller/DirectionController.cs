using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Physics2D;

//? 확인함.
//? 질문 : 0개
//? 확인 필요 : 1개

//* 몬스터의 움직임을 랜덤하게 제어하는 투명한 오브젝트 작동에 관여하는 스크립트.
public class DirectionController : MotionConnector, IControllable<MotionalState>
{
    // 움직임 관련 멤버 변수.
    [SerializeField] float speed;
    [SerializeField] private bool isRandom = false;

    // 스크립트와 같이 사용할 오브젝트의 레이어를 담아주는 List.
    [SerializeField] private List<LayerMask> detectableLayerMasks = new();

    // X, Y 방향을 랜덤으로 지정해줄 때 사용하는 프로파티.
    // 기존 방향을 얻을수도 있으나 해당 코드 파일에서는 사용하지 않았음.
    public float X { get => State.DirectionX; set => State.DirectionX = value; }
    public float Y { get => State.DirectionY; set => State.DirectionY = value; }

    // 오브젝트와 몬스터가 닿였는지 확인해주는 읽기 전용 프로퍼티.
    public bool IsDetected
    {
        get
        {
            return Raycast(transform.position, State.Direction, State.Speed, detectableLayerMasks[0]);
        }
    }

    // 랜덤하게 방향을 설정해주는 메서드.
    public void OnRandom()
    {
        const int min = 0;
        const int max = 1;
        const int maxPlus = max + 1;

        // 0과 1 중 하나를 랜덤하게 받는다.
        // 0의 경우 : 왼쪽
        // 1의 경우 : 오른쪽
        X = Random.Range(min, maxPlus) > 0 ? -1f : 1f;
    }

    // 인스펙터에서 지정해준 레이어들을 모아주는 메서드.
    void MergeLayerMask()
    {
        for (int i = 1; i < detectableLayerMasks.Count; i++)
        {
            detectableLayerMasks[0] += detectableLayerMasks[i];
        }
    }

    // 유니티에서 제공하는 함수.
    protected override void Awake()
    {
        // 상속받은 MotionConnecter의 Awake 함수도 같이 불러옴.
        base.Awake();

        MergeLayerMask();
        OnRandom();

        // TODO : 정확히 어느 코드와 같이 작동하는지 확인하기.
        State.Speed = speed;
    }

    private void Update()
    {
        // 랜덤 기능이 활성화 됐다면 랜덤 방향 기능 또한 활성화 함.
        if (isRandom)
        {
            if (IsDetected)
            {
                OnRandom();
            }
            return;
        }
    }
}
