using UnityEngine;

namespace GameGuruDevChallange.Patterns.StateMachine
{
    public class PlayerRunState : BaseStateWithAnimator
    {
        public PlayerRunState(Animator animator, string animName) : base(animator, animName)
        {
        }
    }
}