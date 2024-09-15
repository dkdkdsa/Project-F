using System;
using UnityEngine;

public abstract class StrategyBase : ScriptableObject, ICloneable, IDisposable
{

    public abstract void Init(params object[] datas);
    public abstract void Excute(params object[] datas);

    public virtual object Clone()
    {

        return Instantiate(this);

    }

    public virtual void Dispose()
    {
    }

}
