using Unity.Mathematics;
using UnityEngine;

public class SpriteFlip : MonoBehaviour, IFlip, ILocalInject
{

    private IRenderer _renderer;

    public void LocalInject(ComponentList list)
    {

        _renderer = list.Find<IRenderer>();

    }

    public void Flip(Vector2 flipVec)
    {

        if (flipVec == Vector2.zero)
            return;

        _renderer.SetFlip(new bool2(flipVec.x > 0, false));

    }

}
