using System;
using UnityEngine;

//? 확인함.
//? 질문 : 2개
//? 확인 필요 : 1개

//* 받은 객체를 작동에 관여하는 다른 코드로 보내주는 스크립트.
public class MotionConnector : MonoBehaviour, IMotionConnectable
{
    public MotionConnector()
    {
        MotionConnectable = this;
    }

    IMotionConnectable MotionConnectable { get; }

    // 인스펙터에서 객체를 꽂아줄 수 있음.
    [field:SerializeField] public virtual Component Component { get; set; }

    // TODO : 자동 구현 프로퍼티에 대해 알아보기.
    //! 질문 : 이 프로퍼티의 역할을 잘 모르겠습니다.
    public MotionalState State { get; set; }

    // 튜플로 선언된 프로퍼티.
    // 튜플은 구조체이기 때문에 생성자에서 무조건 멤버 변수들을 초기화 해주어야 한다.
    //! 질문 : 튜플을 간접적으로 사용한 부분.
    public (float speed, Vector2 direction) Handle { get => State.Handle; set => State.Handle = value; }

    // 유니티에서 제공하는 함수.
    protected virtual void Awake()
    {
        // 1. 인스펙터에서 꽂아준 객체를 사용할 수 있도록 담아줌.
        // 2. IMotionConnectable 타입의 this이므로
        //    (IMotionConnectable타입인 this).Join 이라고 볼수 있음.
        MotionConnectable.Join = Component;
    }
}

