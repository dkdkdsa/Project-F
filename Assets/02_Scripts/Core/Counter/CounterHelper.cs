using System;
using System.Collections.Generic;

public static class CounterHelper
{

    private static Dictionary<Type, ICloneable> _bindContainer = new()
    {

        //IntCounter
        {
            typeof(int),
            new IntCounter()
        },

    };

    public static ICounter<T> GetCounter<T>(CounterRole role, T defaultValue = default(T))
    {

        var ins = _bindContainer[typeof(T)].Clone<ICounter<T>>();
        ins.Role = role;
        ins.Value = defaultValue;

        return ins;

    }

}
