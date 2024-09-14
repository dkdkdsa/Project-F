using System;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon, ILocalInject
{

    #region Hash
    protected readonly int HASH_COOL_TIME = "CoolTime".GetHash();
    #endregion

    protected IStatContainer _stat;
    protected bool _isCoolTime;

    public float CoolTime
    {

        get => _stat[HASH_COOL_TIME].Value;
        set
        {
            _stat[HASH_COOL_TIME].SetValue(value);
        }

    }

    public event Action<object> AttackEvent;
    public event Action<object> RotateEvent;
    public event Action<object> ReleaseEvent;

    public virtual void LocalInject(ComponentList list)
    {

        _stat = list.Find<IStatContainer>();

    }

    public void Attack(object extraData = null)
    {

        if (_isCoolTime)
            return;

        _isCoolTime = true;
        TimerHelper.StartTimer(CoolTime).OnEndEvent += HandleCoolDownEnd;

        DoAttack(extraData);

    }

    private void HandleCoolDownEnd(float t)
    {

        _isCoolTime = false;

    }

    public abstract void DoAttack(object extraData = null);
    public abstract void Rotate(object extraData = null);

    public virtual void Release(object extraData)
    {

        Destroy(gameObject);

    }


}