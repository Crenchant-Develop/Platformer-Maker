using UnityEngine;
using Rigidbody = UnityEngine.Rigidbody2D;

//? 확인함.
//? 질문 : 0개
//? 확인 필요 : 0개

//* 가속도를 설정하는 메서드들이 포함된 스크립트.
public static class MotionableExtender
{
    public static void SetVelocity(this Transform transform, float speed, Vector3 direction, float deltaTime)
    {
        transform.Translate(speed * direction * deltaTime);
    }

    public static void SetVelocity(this Transform transform, float speed, Vector3 direction)
    {
        transform.Translate(speed * direction * Time.deltaTime);
    }

    public static void SetVelocity(this Rigidbody rigidbody, float speed, Vector3 direction)
    {
        rigidbody.velocity = speed * direction;
    }

    public static void SetVelocity(this (float speed, Vector2 direction) motionable, float speed, Vector3 direction)
    {
        motionable.speed = speed;
        motionable.direction = direction;
    }
}