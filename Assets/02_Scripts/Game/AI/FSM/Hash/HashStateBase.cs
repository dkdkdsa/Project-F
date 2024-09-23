using System;
using UnityEngine;

namespace FSM.Hash
{

    public abstract class HashStateBase : MonoBehaviour, IState
    {

        protected Transform _transform { get; private set; }
        protected GameObject _gameObject { get; private set; }

        public virtual void Init(GameObject ownerObject)
        {
            _gameObject = ownerObject;
            _transform = ownerObject.transform;
        }

        public virtual void Enter()
        {
        }
        public virtual void Update()
        {
        }
        public virtual void FixedUpdate()
        {
        }
        public virtual void Exit()
        {
        }
        public virtual void Destroy()
        {
        }
    }
}