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

        public PlayerStateManager(Animator playerAnimator, IMoverAttributes moverAttributes, Transform playerMoveTarget, Transform playerTransform, Rigidbody rigidbody)
        {
            _stateMachine = new StateMachine();
            _playerIdleState = new PlayerIdleState(playerAnimator, "Idle", this);
            _playerRunState = new PlayerRunState(playerAnimator, "Run", moverAttributes, playerMoveTarget, playerTransform);
            _playerCelebrateState = new PlayerCelebrateState(playerAnimator, "Celebrate");
            _playerFallState = new PlayerFallState(playerAnimator, "Fall", rigidbody);
            _stateMachine.ChangeState(_playerIdleState);
        }

        public void Update()
        {
            _stateMachine.Update();
        }

        public void ChangePlayerToIdle()
        {
            _stateMachine.ChangeState(_playerIdleState);
        }

        public void ChangePlayerToRun()
        {
            _stateMachine.ChangeState(_playerRunState);
        }

        public void ChangePlayerToFall()
        {
            _stateMachine.ChangeState(_playerFallState);
        }
    }
}