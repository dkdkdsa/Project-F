using UnityEngine;

public interface ITransition
{

    public void Init(GameObject ownerObject);
    public bool Check();

}