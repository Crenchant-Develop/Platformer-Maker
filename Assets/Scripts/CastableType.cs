using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


[Serializable]
struct CastableObject<TData, TResult>
where TData : IConvertible
where TResult : IConvertible
{
    [SerializeField]
    private TData target;
    private TResult value;

    public TData Target
    {
        get
        {
            return target;
        }
        set
        {
            Cast(value);
            return;
        }
    }
    public TResult Value { get => value; set => Cast(value); }

    public static implicit operator CastableObject<TData, TResult>(TData data) => new(data);
    public static implicit operator CastableObject<TData, TResult>(TResult value) => new(value);

    public static implicit operator TData(CastableObject<TData, TResult> casted) => casted.Target;
    public static implicit operator TResult(CastableObject<TData, TResult> casted) => casted.Value;

    public void Cast(TData convertible)
    {
        target = convertible;
        value = (TResult)(IConvertible)convertible;
    }

    public void Cast(TResult convertible)
    {
        target = (TData)(IConvertible)convertible;
        value = convertible;
    }

    public CastableObject(TData data) : this()
    {
        Target = data;
    }

    public CastableObject(TResult value) : this()
    {
        Value = value;
    }
}