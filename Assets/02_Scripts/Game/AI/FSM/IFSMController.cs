using UnityEngine;

public interface IFSMController<T>
{

    public T CurrentState { get; }

    public void ChangeState(T state);
}