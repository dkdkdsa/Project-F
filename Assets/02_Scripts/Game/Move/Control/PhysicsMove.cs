using UnityEngine;

public class Physicsove : MonoBehaviour, IMoveable, ILocalInject
{

    private IPhysics _physics;

    public void LocalInject(ComponentList list)
    {

        _physics = list.Find<IPhysics>();

    }

    public void Move(in Vector2 moveVector, in float speed)
    {

        Vector3 vec = moveVector * speed;
        vec.y = _physics.GetVelocity().y;
        _physics.SetVelocity(vec);

    }

}
