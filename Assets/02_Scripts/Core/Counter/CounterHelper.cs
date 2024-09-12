using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CounterHelper
{

    private static Dictionary<Type, ICounterable> _bindContainer = new()
    {

        //IntCounter
        {
            typeof(int),
            new IntCounter()
        },

    };

    public static ICounter<T> GetCounter<T>(CounterRole role, T defaultValue = default(T))
    {

        var ins = _bindContainer[typeof(T)].Clone() as ICounter<T>;
        ins.Role = role;
        ins.Value = defaultValue;

        return ins;

    }

}
