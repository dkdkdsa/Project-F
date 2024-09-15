public interface IHp
{
    public delegate void HpChanged(float current, float delta);
    public event HpChanged OnHpChangeEvent;
    public float Hp { get; }

    public void TakeDamage(float damage);
    public void Heal(float value);

}