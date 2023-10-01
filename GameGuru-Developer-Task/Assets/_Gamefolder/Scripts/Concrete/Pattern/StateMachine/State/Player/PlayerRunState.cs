using GameGuruDevChallange.Abstract.Movers;
using UnityEngine;

namespace GameGuruDevChallange.Patterns.StateMachine
{
    public class PlayerRunState : BaseStateWithAnimator
    {
        IMover _mover;
        Transform _playerMoveTarget, _playerTransform;

        public PlayerRunState(Animator animator, string animName, IMoverAttributes moverAttributes, Transform playerMoveTarget, Transform playerTransform) : base(animator, animName)
        {
            _mover = new PlayerMover(moverAttributes);
            _playerMoveTarget = playerMoveTarget;
            _playerTransform = playerTransform;
        }

        public override void Update()
        {
            _mover.Move(_playerTransform, _playerMoveTarget.position);
        }

        public override void Exit()
        {
            base.Exit();
            _mover.StopMovement();
        }
    }
}