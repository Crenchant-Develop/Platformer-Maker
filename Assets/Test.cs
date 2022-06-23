using UnityEngine;

class Test : MonoBehaviour, IAction<Vector2>
{
    void IAction.Invoke<T, State>(T controller)
    {
    }

    public void Invoke<T1, T2>(T1 controller) where T1 : IController<T2>
    {
    }

    private void Awake()
    {
        
    }
}
