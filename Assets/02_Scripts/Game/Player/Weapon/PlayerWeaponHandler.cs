using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour, IWeaponHandler, ILocalInject
{

    #region Hash
    private readonly int HASH_ATTACK = "Attack".GetHash();
    private readonly int HASH_MOUSE = "Mouse".GetHash();
    #endregion

    [SerializeField] private Transform _weaponRoot;

    private IInputContainer _input;
    private IWeapon _currentWeapon;

    public IWeapon CurrentWeapon
    {
        get => _currentWeapon;
        set
        {
            Equip(value);
        }
    }

    public void LocalInject(ComponentList list)
    {

        _input = list.Find<IInputContainer>();

    }

    private void Awake()
    {

        _input.RegisterEvent(HASH_ATTACK, Attack);

    }

    public void Attack(object extraData = null)
    {

        if (extraData == null)
            return;

        _currentWeapon.Attack(extraData);

    }

    public void Equip(IWeapon weapon)
    {

        if (_currentWeapon != null)
            Release();

        _currentWeapon = weapon;

    }

    public void Release(object extraData = null)
    {

        _currentWeapon.Release();
        _currentWeapon = null;

    }

    public void Rotate(object extraData = null)
    {

        _currentWeapon.Rotate(_input.GetValue<Vector2>(HASH_MOUSE));

    }

    private void OnDestroy()
    {

        if (_input != null)
        {

            _input.UnregisterEvent(HASH_ATTACK, Attack);

        }

    }

}