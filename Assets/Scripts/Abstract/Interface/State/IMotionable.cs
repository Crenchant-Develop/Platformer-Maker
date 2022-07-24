using UnityEngine;

//? 확인함.
//? 질문 : 0개
//? 확인 필요 : 0개

//* 속도와 방향을 담는 인터페이스.
public interface IMotionable : IStateHandler<(float speed, Vector2 direction)>
{
    public float Speed { get => Handle.speed; }
    public Vector2 Direction { get => Handle.direction; }
}

//* 가속도를 담는 인터페이스.
interface IVellocity
{
    public Vector2 Velocity { get; }
}

