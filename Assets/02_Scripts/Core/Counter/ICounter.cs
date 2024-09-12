using System;

public enum CounterRole
{

    Plus,
    Subtract

}

public interface ICounterable : ICloneable { }

public interface ICounter<T> : ICounterable
{

    public CounterRole Role { get; set; }
    public T Value { get; set; }
    public T ApplyRole();
    public void SetValue(T value);

}