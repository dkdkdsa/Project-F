using System;
using UnityEngine;

public abstract class HashTransitionBase : ScriptableObject, ITransition, ICloneable
{


    private int _nextState;
    protected GameObject _gameObject { get; private set; }
    protected Transform _transform { get; private set; }

    public abstract bool Check();

    public virtual object Clone()
    {

        return Instantiate(this);

    }

    public object GetNextState()
    {

        return _nextState;

    }

    public virtual void Init(GameObject ownerObject)
    {

        _gameObject = ownerObject;
        _transform = ownerObject.transform;

    }

    public void SetNextState(object state)
    {

        _nextState = state.Cast<int>();

    }
}
