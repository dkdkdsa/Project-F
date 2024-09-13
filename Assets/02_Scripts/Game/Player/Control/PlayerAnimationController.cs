using UnityEngine;

public class PlayerAnimationController : MonoBehaviour, ILocalInject
{

    #region AnimationHash
    private readonly int ANIME_IS_MOVE = Animator.StringToHash("IsMove");
    private readonly int ANIME_Y_INT = Animator.StringToHash("Y");
    private readonly int ANIME_Y_FLOAT = Animator.StringToHash("Y_F");
    #endregion

    #region InputHash
    private readonly int INPUT_MOVE = "Move".GetHash();
    #endregion

    private IInputContainer _input;
    private IAnimator _animator;
    private IPhysics _physics;
    private ISencer _ground;

    public void LocalInject(ComponentList list)
    {

        _input = list.Find<IInputContainer>();
        _animator = list.Find<IAnimator>();
        _physics = list.Find<IPhysics>();
        _ground = list.Find<ISencer>();

    }

    private void Update()
    {

        _animator.SetBool(ANIME_IS_MOVE, GetIsMove());

        int y = GetY();
        _animator.SetInt(ANIME_Y_INT, y);
        _animator.SetFloat(ANIME_Y_FLOAT, y);

    }

    private bool GetIsMove()
    {

        var inputX = _input.GetValue<Vector2>(INPUT_MOVE).x;
        var phyX = _physics.GetVelocity().x;

        return inputX != 0 && phyX != 0;

    }

    private int GetY()
    {

        if (_ground.CheckSencing())
            return 0;

        return _physics.GetVelocity().y > 0 ? 1 : -1;

    }

}
