using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour, ILocalInject
{

    private readonly int HASH_MOVE = "Move".GetHash();
    private readonly int HASH_JUMP = "Jump".GetHash();

    private IInputContainer _input;
    private ISencer _groundSencer;
    private IStatContainer _stat;
    private ICounter<>
    private IMoveable _move;
    private IJumpable _jump;

    public void LocalInject(ComponentList list)
    {

        _input = list.Find<IInputContainer>();
        _groundSencer = list.Find<ISencer>();
        _stat = list.Find<IStatContainer>();
        _move = list.Find<IMoveable>();
        _jump = list.Find<IJumpable>();

    }

    private void Awake()
    {

        _input.RegisterEvent(HASH_JUMP, HandleJump);

    }

    private void FixedUpdate()
    {

        _move.Move(_input.GetValue<Vector2>(HASH_MOVE), _stat[HASH_MOVE].Value);

    }

    private void HandleJump(object obj)
    {

        if (!_groundSencer.CheckSencing())
            return;

        _jump.Jump(_stat[HASH_JUMP].Value);

    }

    private void OnDestroy()
    {
        
        if(_input != null)
        {

            _input.UnregisterEvent(HASH_JUMP, HandleJump);

        }

    }

}
