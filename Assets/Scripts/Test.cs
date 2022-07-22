using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

class Test : MonoBehaviour
{
    public Func<dynamic> refer;

    public Test(Func<dynamic> refer)
    {
        this.refer = refer;
    }

    private void Awake()
    {
    }

    public static implicit operator Test(Func<dynamic> v)
    {
        return new Test(v);
    }
}