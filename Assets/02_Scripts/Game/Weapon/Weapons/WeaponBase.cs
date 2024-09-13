using System;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon, ILocalInject
{

    #region Hash
    protected readonly int HASH_COOL_TIME = "CoolTime".GetHash();
    #endregion

    private IStatContainer _stat;

    protected bool _isCoolTime;

    public float CoolTime => _stat[HASH_COOL_TIME].Value;

    public event Action<object> AttackEvent;
    public event Action<object> RotateEvent;
    public event Action<object> ReleaseEvent;

    public virtual void LocalInject(ComponentList list)
    {

        _stat = list.Find<IStatContainer>();

    }

    public void Attack()
    {

        if (_isCoolTime)
            return;

        _isCoolTime = true;
        TimerHelper.StartTimer(CoolTime).OnEndEvent += HandleCoolDownEnd;

        DoAttack();

    }

    private void HandleCoolDownEnd(float t)
    {

        _isCoolTime = false;

    }

    public abstract void DoAttack();
    public abstract void Rotate();

    public virtual void Release()
    {

        Destroy(gameObject);

    }


}