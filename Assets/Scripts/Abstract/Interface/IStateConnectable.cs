using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateConnectable<T>
where T : class, new()
{
    protected readonly static Dictionary<Object, T> states = new ();
    
    public Object Object { get; set; }
    public T State { get; set; }

    public IEnumerator Join()
    {
        //아직 존재하지않는 키값이면 State공유함.
        if (!states.ContainsKey(Object))
        {
            states.Add(Object, State);
        }

        //공유했는데도 불구하고 값이 null이면 기다림.
        while (states[Object] is null)
        {
            if (State is not null)
            {
                states[Object] = State;
            }
            yield return null;
        }
        State = states[Object];
    }
}