using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDebug : MonoBehaviour
{
    [SerializeField] private WeaponBase _weapon;
    [SerializeField] private PlayerWeaponHandler _weaponHandler;

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F))
            _weaponHandler.CurrentWeapon = _weapon;

    }

}
