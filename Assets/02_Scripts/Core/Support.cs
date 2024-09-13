using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Support
{

    public static int GetHash(this string value)
    {

        return value.GetHashCode();

    }

    public static T Clone<T>(this ICloneable source) where T : ICloneable
    {

        return (T)source.Clone();

    }

    public static T Cast<T>(this object source)
    {

        return (T)source;

    }

    public static int GetGameObjectId(this Component comp)
    {

        return comp.gameObject.GetInstanceID();

    }

    public static T GetRandom<T>(this List<T> target)
    {

        return target[Random.Range(0, target.Count)];

    }


}
