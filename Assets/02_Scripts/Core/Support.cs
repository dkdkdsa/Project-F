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

    public static T Clone<T>(this T source) where T : ICloneable
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

    public static Transform[] GetChilds(this Transform transform)
    {

        Transform[] children = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i);
        }

        return children;
        
    }

}
