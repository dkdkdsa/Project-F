using System;

public interface IWeapon
{

    public event Action<object> AttackEvent;
    public event Action<object> RotateEvent;
    public event Action<object> ReleaseEvent;

    public void Attack();
    public void Rotate();
    public void Release();

}