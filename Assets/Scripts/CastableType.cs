using System;
using UnityEngine;

[Serializable]
struct CastableType<KeyT, ValueT>
{
    [SerializeField] KeyT key;
    ValueT value;

    public KeyT Key { get => key; }
    public ValueT Value { get => value; }

    public static implicit operator CastableType<KeyT, ValueT>(KeyT key) => new(key);
    public static implicit operator CastableType<KeyT, ValueT>(ValueT value) => new(value);

    public static implicit operator KeyT(CastableType<KeyT, ValueT> casted) => casted.key;
    public static implicit operator ValueT(CastableType<KeyT, ValueT> casted) => casted.value;

    private CastableType(KeyT key)
    {
        this.key = key;
        value = (ValueT)(key as IConvertible);
    }

    private CastableType(ValueT value)
    {
        key = (KeyT)(value as IConvertible);
        this.value = value;
    }

    public CastableType(KeyT key, ValueT value)
    {
        this.key = key;
        this.value = value;
    }
}