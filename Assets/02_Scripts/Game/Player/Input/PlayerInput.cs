using UnityEngine;
using UnityEngine.InputSystem;

public enum InputType
{

    Down,
    Up

}

public class PlayerInput : InputContainerBase, InputMap.IPlayerActions
{

    private readonly int HASH_JUMP = "Jump".GetHash();
    private readonly int HASH_MOVE = "Move".GetHash();
    private readonly int HASH_ATTACK = "Attack".GetHash();
    private readonly int HASH_MOUSE = "Mouse".GetHash();

    private InputMap _input;

    private void Awake()
    {

        _input = new InputMap();
        _input.Player.SetCallbacks(this);
        _input.Player.Enable();

    }

    public void OnJump(InputAction.CallbackContext context)
    {

        if (_eventContainer.ContainsKey(HASH_JUMP) && context.performed)
            _eventContainer[HASH_JUMP].Invoke(null);

    }

    public void OnMove(InputAction.CallbackContext context)
    {

        if (!_valueContainer.ContainsKey(HASH_MOVE))
            _valueContainer.Add(HASH_MOVE, Vector2.zero);

        var vec = context.ReadValue<Vector2>();
        vec.y = 0;

        _valueContainer[HASH_MOVE] = vec;

    }

    public void OnAttack(InputAction.CallbackContext context)
    {

        if (!_eventContainer.ContainsKey(HASH_ATTACK))
            return;
        if(context.performed)
            _eventContainer[HASH_ATTACK].Invoke(InputType.Down);
        else if(context.canceled)
            _eventContainer[HASH_ATTACK].Invoke(InputType.Up);

    }

    public void OnMouse(InputAction.CallbackContext context)
    {

        if (!_valueContainer.ContainsKey(HASH_MOUSE))
            _valueContainer.Add(HASH_MOUSE, Vector2.zero);

        var vec = context.ReadValue<Vector2>();

        _valueContainer[HASH_MOUSE] = vec;

    }
}
