using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorProvider : MonoBehaviour, IAnimator
{

    private Animator _animator;

    private void Awake()
    {

        _animator = GetComponent<Animator>();

    }

    public void SetBool(int hash, bool value) => _animator.SetBool(hash, value);
    public void SetFloat(int hash, float value) => _animator.SetFloat(hash, value);
    public void SetInt(int hash, int value) => _animator.SetInteger(hash, value);
    public void SetTrigger(int hash) => _animator.SetTrigger(hash);

}
