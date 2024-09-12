using UnityEngine;

public class PhysicsJump : MonoBehaviour, IJumpable, ILocalInject
{

    private IPhysics _physics;

    public void LocalInject(ComponentList list)
    {

        _physics = list.Find<IPhysics>();

    }

    public void Jump(float jumpPower)
    {

        _physics.AddForce(Vector3.up * jumpPower);

    }

}
