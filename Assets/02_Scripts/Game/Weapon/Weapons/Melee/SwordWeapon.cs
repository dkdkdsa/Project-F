using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : MeleeWeaopnBase
{
    public override void DoAttack(object extraData = null)
    {


    }

    public override void Rotate(object extraData = null)
    {

        if (extraData == null)
            return;

        var rawVec = extraData.Cast<Vector2>();
        var vec = Camera.main.ScreenToWorldPoint(rawVec);
        vec.z = 0;

        var dir = vec - _root.position;
        _root.right = dir.normalized;

    }

}
