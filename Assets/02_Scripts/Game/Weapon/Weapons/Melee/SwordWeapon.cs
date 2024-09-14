using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : MeleeWeaopnBase
{

    private IFlip _flip;

    public override void LocalInject(ComponentList list)
    {

        base.LocalInject(list);

        _flip = list.Find<IFlip>();

    }

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
        _flip.Flip(dir.normalized);

    }

}
