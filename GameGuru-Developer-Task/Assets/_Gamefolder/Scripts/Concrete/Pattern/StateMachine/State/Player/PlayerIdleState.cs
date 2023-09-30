using System.Collections;
using System.Collections.Generic;
using GameGuruDevChallange.Abstract.Patterns;
using UnityEngine;

namespace GameGuruDevChallange.Patterns.StateMachine
{
    public class PlayerIdleState : BaseStateWithAnimator
    {
        public PlayerIdleState(Animator animator, string animName) : base(animator, animName)
        {
        }
    }
}