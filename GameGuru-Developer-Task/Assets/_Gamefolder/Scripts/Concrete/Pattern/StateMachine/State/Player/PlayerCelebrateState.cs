using UnityEngine;

namespace GameGuruDevChallange.Patterns.StateMachine
{
    public class PlayerCelebrateState : BaseStateWithAnimator
    {
        public PlayerCelebrateState(Animator animator, string animName) : base(animator, animName)
        {
        }
    }
}