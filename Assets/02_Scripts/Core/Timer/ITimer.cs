using System;
public interface ITimer<T> : ICloneable
{

    public event Action<T> OnTickEvent;
    public event Action<T> OnEndEvent;
    public T Value { get; }

    public void SetTime(T value);
    public void StartTimer();

}