using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IControllable<T> : IStatable<T> where T : class, IStatable<object>
{
    public T State { get; set; }
}