using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public interface IControllable<out T> : IStateConnectable<T>
where T : class, IStatable
{
}


