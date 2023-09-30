using GameGuruDevChallange.Abstract.Patterns;
using UnityEngine;

public abstract class BaseStateWithAnimator : IState
{
    Animator _animator;
    string _animName;

    public BaseStateWithAnimator(Animator animator, string animName)
    {
        _animator = animator;
        _animName = animName;
    }

    public virtual void Enter()
    {
        _animator.SetBool(_animName, true);
    }

    public virtual void Update()
    {
    }

    public virtual void Exit()
    {
        _animator.SetBool(_animName, false);
    }
}