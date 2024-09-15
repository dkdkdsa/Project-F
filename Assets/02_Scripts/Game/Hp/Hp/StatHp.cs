using UnityEngine;

public class StatHp : ObjectHp, ILocalInject
{

    #region
    private readonly int HASH_HP = "Hp".GetHash();
    #endregion

    private IStatContainer _stat;
    private float _maxHp;

    public void LocalInject(ComponentList list)
    {

        _stat = list.Find<IStatContainer>();

    }

    private void Awake()
    {

        _hp = _maxHp = _stat[HASH_HP].Value;

    }

    public override void Heal(float value)
    {

        base.Heal(value);

        _hp = Mathf.Clamp(_hp, 0, _maxHp);

    }

}