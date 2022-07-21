using UnityEngine;

public class MotionalState : IMotionable
{
    public (float speed, Vector2 direction) Handle { get; set; }
}