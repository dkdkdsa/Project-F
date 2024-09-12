using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputContainerBase : MonoBehaviour, IInputContainer
{

    protected Dictionary<int, Action<object>> _eventContainer = new();
    protected Dictionary<int, object> _valueContainer = new();

    public void RegisterEvent(int key, Action<object> @event)
    {

        if (_eventContainer.ContainsKey(key))
            _eventContainer[key] += @event;
        else
            _eventContainer.Add(key, @event);

    }

    public void UnregisterEvent(int key, Action<object> @event)
    {

        if (_eventContainer.ContainsKey(key))
            _eventContainer[key] -= @event;

    }

    public T GetValue<T>(int key) where T : struct
    {

        if (_valueContainer.TryGetValue(key, out var value))
            return (T)value;

        return default(T);

    }

}
