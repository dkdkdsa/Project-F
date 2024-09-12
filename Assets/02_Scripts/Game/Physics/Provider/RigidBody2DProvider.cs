using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidBody2DProvider : ExpansionMonoBehaviour, IPhysics
{

    private Rigidbody2D _rigid;

    private void Awake()
    {

        _rigid = GetComponent<Rigidbody2D>();

    }

    public Vector3 GetVelocity()
    {

        if (_rigid != null)
            return _rigid.velocity;

        Debug.LogError("RigidBody is Null");
        return Vector3.zero;

    }

    public void SetVelocity(Vector3 val)
    {

        if (_rigid != null)
            _rigid.velocity = val;

    }

    public void AddFource(Vector3 fource, ForceMode2D mode = ForceMode2D.Impulse)
    {

        _rigid.AddForce(fource, mode);

    }

}
