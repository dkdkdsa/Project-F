public interface IWeaponHandler
{

    public IWeapon CurrentWeapon { get; set; }
    public void Equip(IWeapon weapon);
    public void Release();
    public void Attack();
    public void Rotate();

}