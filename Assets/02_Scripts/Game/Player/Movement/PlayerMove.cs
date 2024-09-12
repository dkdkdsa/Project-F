using UnityEngine;

public class PlayerMove : MonoBehaviour, IMoveable, ILocalInject
{

    private IPhysics _physics;

    public void LocalInject(ComponentList list)
    {

        _physics = list.Find<IPhysics>();

    }

    public void Move(in Vector2 moveVector, in float speed)
    {

        _physics.AddForce((moveVector * speed * Time.fixedDeltaTime), ForceMode2D.Force);

    }

}
