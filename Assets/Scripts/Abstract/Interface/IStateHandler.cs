using System;
using System.Runtime.CompilerServices;

//? 확인함.
//? 질문 : 1개
//? 확인 필요 : 0개

//* 상태를 감지하는 역할을 하는 스크립트.
public interface IStateHandler<T> : IEquatable<T>
where T : new()
{
    T Handle { get; set; }

    //! 질문 : 이 메서드가 서로 맞는지 확인하는 역할을 하는건 알겠는데
    //!       뭐가 맞는지 확인하는 건지는 잘 모르겠습니다.
    bool IEquatable<T>.Equals(T other)
    {
        return Handle.Equals(other);
    }
}
