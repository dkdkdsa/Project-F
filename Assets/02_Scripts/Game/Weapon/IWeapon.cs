using System;

public interface IWeapon
{

    public event Action<object> AttackEvent;
    public event Action<object> RotateEvent;
    public event Action<object> ReleaseEvent;

    public void SetUp(object extraData = null);
    public void Attack(object extraData = null);
    public void Rotate(object extraData = null);
    public void Release(object extraData = null);

}