using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{

    public event Action<object> AttackEvent;
    public event Action<object> RotateEvent;
    public event Action<object> ReleaseEvent;

    public void Attack()
    {
    }

    public abstract void DoAttack();
    public abstract void Rotate();

    public virtual void Release()
    {

        Destroy(gameObject);

    }

}