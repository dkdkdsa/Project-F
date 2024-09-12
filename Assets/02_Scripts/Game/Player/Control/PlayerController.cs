using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ILocalInject
{

    private readonly int HASH_MOVE = "Move".GetHash();
    private readonly int HASH_JUMP = "Jump".GetHash();

    private IInputContainer _input;
    private IMoveable _move;
    private IJumpable _jump;
    private ISencer _groundSencer;

    public void LocalInject(ComponentList list)
    {

        _input = list.Find<IInputContainer>();
        _groundSencer = list.Find<ISencer>();
        _move = list.Find<IMoveable>();
        _jump = list.Find<IJumpable>();

    }

    private void Awake()
    {

        _input.RegisterEvent(HASH_JUMP, HandleJump);

    }

    private void FixedUpdate()
    {

        Debug.Log(_input.GetValue<Vector2>(HASH_MOVE));
        _move.Move(_input.GetValue<Vector2>(HASH_MOVE), 3);

    }

    private void HandleJump(object obj)
    {

        if (!_groundSencer.CheckSencing())
            return;

        _jump.Jump(3);

    }

    private void OnDestroy()
    {
        
        if(_input != null)
        {

            _input.UnregisterEvent(HASH_JUMP, HandleJump);

        }

    }

}
