using System.Collections.Generic;
using UnityEngine;

namespace FSM.Hash
{

    public class HashFSMController : IFSMController<int>
    {

        private Dictionary<int, List<ITransition>> _transitionContainer = new();
        private Dictionary<int, IState> _stateContainer = new();

        private bool _stateChangeFlag;
        private int _currentState;
        public int CurrentState => _currentState;

        public HashFSMController(GameObject ownerObject)
        {


        }

        public void ChangeState(int state)
        {

            _stateContainer[_currentState].Exit();
            _currentState = state;
            _stateContainer[_currentState].Enter();

            _stateChangeFlag = true;

        }

        public void Update()
        {

            _stateChangeFlag = false;

            foreach (var trans in _transitionContainer[_currentState])
            {

                trans.Check();

                if (_stateChangeFlag)
                    return;

            }

            _stateContainer[_currentState].Update();

        }

        public void FixedUpdate()
        {

            _stateContainer[_currentState].FixedUpdate();

        }

        public void OnDestroy()
        {

            foreach (var item in _stateContainer.Values)
                item.Destroy();

        }

    }

    public interface IHashControllerUse
    {

        public IFSMController<int> Controller { get; }
        public void SetController(IFSMController<int> controller);

    }

}