using System;

public interface IHitable
{

    public event Action<object> OnHitEvent;
    public void Hit(object hitData = null);

}
