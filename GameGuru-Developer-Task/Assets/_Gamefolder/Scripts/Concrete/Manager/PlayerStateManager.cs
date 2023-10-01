using GameGuruDevChallange.Abstract.Patterns;
using GameGuruDevChallange.Patterns.StateMachine;
using UnityEngine;
using StateMachine = GameGuruDevChallange.Patterns.StateMachine.StateMachine;

namespace GameGuruDevChallange.Managers
{
    public class PlayerStateManager
    {
        StateMachine _stateMachine;
        IState _playerIdleState;
        IState _playerRunState;
        IState _playerCelebrateState;
        IState _playerFallState;

        public PlayerStateManager(Animator playerAnimator)
        {
            _stateMachine = new StateMachine();
            _playerIdleState = new PlayerIdleState(playerAnimator, "Idle");
            _playerRunState = new PlayerRunState(playerAnimator, "Run");
            _playerCelebrateState = new PlayerCelebrateState(playerAnimator, "Celebrate");
            _playerFallState = new PlayerFallState(playerAnimator, "Run");
            _stateMachine.ChangeState(_playerIdleState);
        }

        public void Update()
        {
            _stateMachine.Update();
        }
    }
}