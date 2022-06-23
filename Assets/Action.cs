using UnityEngine;

interface IController<StateType>
{
    StateType State { get; set; }
}

interface IAction
{
    void Invoke<T, S>(T handle) where T: class, IController<S>;
}

interface IAction<StateType> : IAction
{
    // 명시적 구현 메소드
    void IAction.Invoke<T, S>(T handle)
    {
        // 형 변환에 실패할 경우 (IController<StateType>를 상속받지 않은 경우)
        // null을 반환하고, 성공할 경우 IController<StateType>으로 형변환된 객체 값을 반환하게 된다.
        Invoke(handle as IController<StateType>);

        // 이 코드블럭이 오류가 안 나는 이유는 c# 최신 버전이기 때문이다.
        // 구버전에서는 되지 않았었다.
    }

    // 구현을 안한 추상 메소드다.
    void Invoke(IController<StateType> controller);
}

class Jump : IAction<Vector2>
{
    public void Invoke(IController<Vector2> controller)
    {
        Debug.Log("점프");
    }
}

class Move : IAction<Vector2>
{
    public void Invoke(IController<Vector2> controller)
    {
        Debug.Log("움직인다");
    }
}

