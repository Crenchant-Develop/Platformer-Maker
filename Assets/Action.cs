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
    // ����� ���� �޼ҵ�
    void IAction.Invoke<T, S>(T handle)
    {
        // �� ��ȯ�� ������ ��� (IController<StateType>�� ��ӹ��� ���� ���)
        // null�� ��ȯ�ϰ�, ������ ��� IController<StateType>���� ����ȯ�� ��ü ���� ��ȯ�ϰ� �ȴ�.
        Invoke(handle as IController<StateType>);

        // �� �ڵ���� ������ �� ���� ������ c# �ֽ� �����̱� �����̴�.
        // ������������ ���� �ʾҾ���.
    }

    // ������ ���� �߻� �޼ҵ��.
    void Invoke(IController<StateType> controller);
}

class Jump : IAction<Vector2>
{
    public void Invoke(IController<Vector2> controller)
    {
        Debug.Log("����");
    }
}

class Move : IAction<Vector2>
{
    public void Invoke(IController<Vector2> controller)
    {
        Debug.Log("�����δ�");
    }
}

