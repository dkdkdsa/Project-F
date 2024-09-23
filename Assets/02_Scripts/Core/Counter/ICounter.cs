using System;

public enum CounterRole
{

    Plus,
    Subtract

}

public interface ICounter<T> : ICloneable
{

    public CounterRole Role { get; set; }
    public T Value { get; set; }
    public T ApplyRule();
    public void SetValue(T value);

}