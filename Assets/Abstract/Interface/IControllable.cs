using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public interface IControllable<T, out StateT> : IStateConnectable<T>
where StateT : class, IStatable<T>
{
}