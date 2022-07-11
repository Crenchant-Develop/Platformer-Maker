using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

// 조작이 가능한 객체의 일반화와 다형성을 위해 정의한 추상 타입의 인터페이스.
public interface IControllable<T> : IStatable<T> where T : class, IStatable<object>
{
    // Generic 타입의 자동 구현 프로퍼티.
    public T State { get; set; }
}