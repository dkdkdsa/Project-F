using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Stat : ICloneable
{

    [SerializeField] private float _value;
    private List<float> _modify = new();

    public float Value
    {

        get
        {

            float v = _value;

            foreach (var item in _modify)
            {

                v += item;

            }

            return v;

        }

    }

    public Stat(Stat ins)
    {

        _value = ins._value;
        _modify = ins._modify == null ? new() : ins._modify.ToList();

    }

    public void AddModify(float value)
    {

        _modify.Add(value);

    }

    public void RemoveModify(float value)
    {

        _modify.Remove(value);

    }

    public object Clone()
    {

        return new Stat(this);

    }

}
