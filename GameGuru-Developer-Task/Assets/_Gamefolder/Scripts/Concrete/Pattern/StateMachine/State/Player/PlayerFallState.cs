using UnityEngine;

namespace GameGuruDevChallange.Patterns.StateMachine
{
    public class PlayerFallState : BaseStateWithAnimator
    {
        public PlayerFallState(Animator animator, string animName) : base(animator, animName)
        {
        }
    }
}