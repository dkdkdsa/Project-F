using UnityEngine;

public class ObjectHp : MonoBehaviour, IHp
{

    protected float _hp;
    
    public float Hp => _hp;

    public event IHp.HpChanged OnHpChangeEvent;

    public virtual void Heal(float value)
    {

        _hp += value;

        OnHpChangeEvent?.Invoke(_hp, value);

    }

    public void TakeDamage(float damage)
    {


        _hp -= damage;
        _hp = Mathf.Clamp(_hp, 0, float.MaxValue);

        OnHpChangeEvent?.Invoke(_hp, damage);

    }

}