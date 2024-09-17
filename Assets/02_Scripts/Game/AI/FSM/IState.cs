using UnityEngine;

public interface IState
{

    public void Init(GameObject ownerObject);
    public void Enter();
    public void Exit();
    public void Update();
    public void FixedUpdate();
    public void Destroy();

}