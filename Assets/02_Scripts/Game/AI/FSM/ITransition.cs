using UnityEngine;

public interface ITransition
{

    public void Init(GameObject ownerObject);
    public bool Check();
    public void SetNextState(object state);
    public object GetNextState();

}