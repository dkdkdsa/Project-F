using System;
using UnityEngine;

public struct AttackData
{

    public float damage;

}

public abstract class WeaponBase : MonoBehaviour, IWeapon, ILocalInject
{

    #region Hash
    protected readonly int HASH_COOL_TIME = "CoolTime".GetHash();
    protected readonly int HASH_PIVOT_X = "PivotX".GetHash();
    protected readonly int HASH_PIVOT_Y = "PivotY".GetHash();
    protected readonly int HASH_DAMAGE = "Damage".GetHash();
    #endregion

    public SubSkillContainer SubSkills { get; set; } = new();
    protected Transform _root => transform.parent;
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

    public float Damage
    {

        get => _stat[HASH_DAMAGE].Value;
        set
        {
            _stat[HASH_DAMAGE].SetValue(value);
        }

    }

    public Vector2 Pivot
    {

        get => new Vector2(_stat[HASH_PIVOT_X].Value, _stat[HASH_PIVOT_Y].Value);
        set
        {

            _stat[HASH_PIVOT_X].SetValue(value.x);
            _stat[HASH_PIVOT_Y].SetValue(value.y);

        }

    }

   

    public event Action<object> AttackEvent;
    public event Action<object> RotateEvent;
    public event Action<object> ReleaseEvent;

    protected void InvokeAttack(object data) => AttackEvent?.Invoke(data);
    protected void InvokeRotate(object data) => RotateEvent?.Invoke(data);
    protected void InvokeRelease(object data) => ReleaseEvent?.Invoke(data);

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

        InvokeRelease(extraData);
        Destroy(gameObject);

    }

    public virtual void SetUp(object extraData = null)
    {

        if (extraData == null)
            return;

        var t = extraData.Cast<Transform>();
        transform.SetParent(t);
        transform.localPosition = Pivot;

    }
}