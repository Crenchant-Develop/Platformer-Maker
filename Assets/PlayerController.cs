using UnityEngine;

class PlayerController : IController<Vector2>
{
    //this의 타입이 IController<Vector2> 일때는 setter만 사용가능함
    public Vector2 State { get; set; }
}
