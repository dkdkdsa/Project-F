using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidBody2DProvider : MonoBehaviour, IPhysics
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

    public void AddForce(Vector3 force, ForceMode2D mode = ForceMode2D.Impulse)
    {

        _rigid.AddForce(force, mode);

    }

    public void MovePosition(Vector3 pos)
    {

        _rigid.MovePosition(pos);

    }
}
