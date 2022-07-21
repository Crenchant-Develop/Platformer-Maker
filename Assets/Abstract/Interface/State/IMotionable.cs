using UnityEngine;

public interface IMotionable : IStateHandler<(float speed, Vector2 direction)>
{
}
