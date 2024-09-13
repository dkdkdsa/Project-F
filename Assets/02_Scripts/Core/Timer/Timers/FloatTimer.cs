using System;
using UnityEngine;

public class FloatTimer : ITimer<float>, IDisposable
{

    private float _value;

    public float Value => _value;

    public event Action<float> OnTickEvent;
    public event Action<float> OnEndEvent;

    public object Clone()
    {

        return new FloatTimer();

    }

    public void StartTimer()
    {

        CycleManager.Instance.UpdateEvent += HandleUpdate;

    }

    private void HandleUpdate()
    {

        _value -= Time.deltaTime;
        OnTickEvent?.Invoke(_value);

        if (_value < 0)
        {

            OnEndEvent?.Invoke(_value);
            Dispose();

        }

    }

    public void Dispose()
    {

        CycleManager.Instance.UpdateEvent -= HandleUpdate;
        OnTickEvent = null;
        OnEndEvent = null;

    }

    public void SetTime(float value)
    {
        _value = value;
    }
}