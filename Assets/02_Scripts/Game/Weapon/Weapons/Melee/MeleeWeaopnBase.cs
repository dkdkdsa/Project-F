using UnityEngine;

public abstract class MeleeWeaopnBase : WeaponBase
{

    #region Hash
    protected readonly int HASH_CASTING_X = "CastingSizeX".GetHash();
    protected readonly int HASH_CASTING_Y = "CastingSizeY".GetHash();
    #endregion

    public Vector2 CastingSize
    {

        get => new Vector2(_stat[HASH_CASTING_X].Value, _stat[HASH_CASTING_Y].Value);
        set
        {

            _stat[HASH_CASTING_X].SetValue(value.x);
            _stat[HASH_CASTING_Y].SetValue(value.y);

        }

    }

}
