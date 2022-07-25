using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

//? 확인함.
//? 질문 : 4개
//? 확인 필요 : 0개

//* (       )하는 스크립트.
//! 질문 : 위에 빈 칸을 채워주세요.
public interface IStateConnectable<T>
where T : class, new()
{
    public T State { get; set; }

    // // 1, 이 프로퍼티 메소드는 대부분 생성자같은 곳에서 호출함.
    // // 2. 해당 오브젝트가 T타입의 State멤버 메소드를 가지고 있는 경우 자신의 State와 동기화됨.
    // // 3. 연결할 객체중에 아무나 State의 값을 가지고 있는 객체가 State가 비어있는 놈한테 값을 생성하고 전달 할 수 있도록 의도해서 로직을 작성했다.
    // //    서로 같은 객체의 레퍼런스를 State에 참조하게 하기위한 로직이다.
    public Component Join
    {
        set
        {
            // value를 IStateConnectable<T> 타입으로 형변환함.
            var stateHandler = CastToState(value);

            // IStateConnectable<T> 라는 인터페이스가 State라는 프로퍼티를 포함하기 때문에
            // stateHandler.State와 같이 State 프로퍼티를 사용할 수 있음.

            // stateHandler.State가 비어있으면 State 프로퍼티에 새로운 T타입의 변수를 담아주고
            // 인스펙터에서 받아온 객체의 State 에 그 값을 담아줌.
            if (stateHandler.State is null)
            {
                // this는 자기 자신이고 stateHandler는 인스펙터에서 받아온 객체이기 때문에
                // this와 stateHandler은 서로 다른 객체라고 볼수 있다.
                // (즉, this.State와 stateHandler.State 또한 서로 다르다.)
                State = new T(); 
                stateHandler.State = State;
                return;
            }

            // stateHandler.State가 비어있지 않다면
            // 단순히 this.State에 받아온 객체의 State를 담아줌.
            State = stateHandler.State;
        }
    }

    // 확장성을 위해 오버로드된 CastToState() 메서드 2개
    //! 질문 : 이 메서드의 역할이 뭔지 잘 모르겠습니다.
    public S CastToState<S>(Component from)
    where S : class, IStateConnectable<T>, new()
    {
        S stateConnectable = from as S ?? from.GetComponent<S>();
        return stateConnectable;
    }

    // 매개변수로 받은 객체를 IStateConnectable<T> 타입으로 형변환 하는 메서드.
    public IStateConnectable<T> CastToState(Component from)
    {
        // 호출하는 메서드가 확장 메서드이기 때문에 from. 을 붙여줌.
        return from.CastToState<T>();
    }
}

// 확장성을 위해 오버로드된 확장 메서드 3개를 담고 있는 클래스.

public static class StateExtender
{
    public static IStateConnectable<T> CastToState<T>(this Component from)
    where T : class, new()
    {
        // (IStateConnectable<T>.State의 타입은 T이다.)
        // 받은 객체(from)이 IStateConnectable<T> 타입이 맞다면
        // stateConnectable 변수에 값을 담아준다. (타입이 다르다면 null 이 담긴다.)
        
        // stateConnectable 변수에 값을 담아준다.
        //! 질문 : as 키워드와 ??를 같이 사용한 경우 어떻게 해석을 해야 하는지 알고싶습니다.
        var stateConnectable =
            from as IStateConnectable<T> ??
            from.GetComponent<IStateConnectable<T>>();
        return stateConnectable;
    }

    //! 질문 : 나머지 오버로드된 메서드들의 용도가 궁금합니다.
    public static IStateConnectable<T> CastToState<T>(this UnityEngine.Object from)
    where T : class, new()
    {
        var stateConnectable =
            (from as IStateConnectable<T>) ??
            (from as Component).GetComponent<IStateConnectable<T>>();
        return stateConnectable;
    }
    public static S CastToState<T, S>(this Component from)
    where S : class, IStateConnectable<T>, new()
    where T : class, new()
    {
        S stateConnectable = from as S ?? from.GetComponent<S>();
        return stateConnectable;
    }
}