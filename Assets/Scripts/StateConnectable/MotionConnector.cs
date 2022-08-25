using UnityEngine;
using Vector = UnityEngine.Vector2;

public abstract class MotionConnector : BindableObject<MotionalState>, IMotionConnectable
{
    public static Vector RadianToVector2(float radian)
    {
        return Quaternion.AngleAxis(radian, Vector3.forward) * Vector2.right;
    }

    public static float GetAngle(Vector3 value)
    {
        return Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg;
    }

    public static float ClampAngle(Vector3 value, float min, float max, out float angle)
    {
        return Mathf.Clamp(angle = GetAngle(value), min, max);
    }
}