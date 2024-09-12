using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : InputContainerBase, InputMap.IPlayerActions
{

    private readonly int HASH_JUMP = "Jump".GetHash();
    private readonly int HASH_MOVE = "Move".GetHash();

    private InputMap _input;

    private void Awake()
    {

        _input = new InputMap();
        _input.Player.SetCallbacks(this);
        _input.Player.Enable();

    }

    public void OnJump(InputAction.CallbackContext context)
    {

        if (_eventContainer.ContainsKey(HASH_JUMP))
            _eventContainer[HASH_JUMP].Invoke(null);

    }

    public void OnMove(InputAction.CallbackContext context)
    {

        if (!_valueContainer.ContainsKey(HASH_MOVE))
            _valueContainer.Add(HASH_MOVE, Vector2.zero);

        var vec = context.ReadValue<Vector2>();
        vec.y = 0;

        _valueContainer.Add(HASH_MOVE, vec);

    }

}
