using UnityEngine;

public interface IPhysics
{

    public Vector3 GetVelocity();
    public void SetVelocity(Vector3 val);
    public void AddForce(Vector3 fource, ForceMode2D mode = ForceMode2D.Impulse);

}
