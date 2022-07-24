using UnityEngine;
using Rigidbody = UnityEngine.Rigidbody2D;

//? 확인함.
//? 질문 : 0개
//? 확인 필요 : 0개

public class Movement : MotionConnector, IActionable<MotionalState>
{
    [field: SerializeField] Rigidbody Rigidbody { get; set; }

    // 유니티에서 제공하는 함수.
    public void Update()
    {
        // 
        Rigidbody.velocity = State.Velocity;
    }
    protected override void Awake()
    {
        // 상속받은 MotionConnecter의 Awake 함수도 같이 불러옴.
        base.Awake();
        Rigidbody = GetComponent<Rigidbody>();
    }
}
