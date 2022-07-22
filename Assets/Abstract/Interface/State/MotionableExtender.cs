using UnityEngine;
using Rigidbody = UnityEngine.Rigidbody2D;

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