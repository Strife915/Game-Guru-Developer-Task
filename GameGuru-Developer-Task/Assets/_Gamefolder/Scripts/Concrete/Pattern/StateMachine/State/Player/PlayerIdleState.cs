using GameGuruDevChallange.Managers;
using UnityEngine;

namespace GameGuruDevChallange.Patterns.StateMachine
{
    public class PlayerIdleState : BaseStateWithAnimator
    {
        PlayerStateManager _playerStateManager;

        public PlayerIdleState(Animator animator, string animName, PlayerStateManager playerStateManager) : base(animator, animName)
        {
            _playerStateManager = playerStateManager;
        }

        public override void Enter()
        {
            base.Enter();
            if (GameManager.Instance.IsGameEnd)
                _playerStateManager.ChangePlayerToFall();
        }
    }
}