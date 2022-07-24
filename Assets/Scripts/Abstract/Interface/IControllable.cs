using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IControllable<T> : IStateConnectable<T>
where T : class, new()
{
}