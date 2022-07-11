using UnityEngine;

// IStatable<string> 인터페이스를 상속받는 추상화 클래스.
//! 질문 : Statable 뜻이랑 이걸로 의도하신 바가 뭔가요?
public abstract class StatableObject : IStatable<string>
{
    public string Name { get; }

    //!
    string IStatable<string>.Handle => Name;

    public (IC, IA) Bind<T, IC, IA>(out IC controllable, out IA actionable)
    where T : StatableObject
    where IC : class, IControllable<T>, new()

    //! 질문 : 추상화 클래슨데 왜 내용을 추가하셨나요?
    where IA : class, IActionable<T>, new()
    {
        T statableObject = this as T;
        controllable = new();
        actionable = new();
        controllable.State = statableObject;
        actionable.State = statableObject;

        return (controllable, actionable);
    }

    public StatableObject(string name)
    {
        Name = name;
    }
}
