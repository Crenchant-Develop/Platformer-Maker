﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public interface IControllable<T, out IStatable> : IStateConnectable<T, IStatable>
where IStatable : class, IStatable<T>
{
}