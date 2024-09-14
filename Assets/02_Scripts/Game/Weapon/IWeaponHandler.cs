public interface IWeaponHandler
{

    public IWeapon CurrentWeapon { get; set; }
    public void Equip(IWeapon weapon);
    public void Release(object extraData = null);
    public void Attack(object extraData = null);
    public void Rotate(object extraData = null);

}