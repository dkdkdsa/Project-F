using FSM.Hash;
using UnityEngine;

public class TestState : HashStateBase
{

    public string logText;

    public override void Enter()
    {

        Debug.Log(logText);

    }

}
