using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

class Test : MonoBehaviour
{
    private void Awake()
    {
        ITuple t = (32, 32);
        (int a, int b) copy = ((int a, int b))t;

        copy.a = 22;

        if (t.Equals(copy))
        {
            print("레퍼런스가 같습니다." + t[0]);
        }
        else
        {
            print("레퍼런스가 다릅니다." + t[0]);
        }
    }
}