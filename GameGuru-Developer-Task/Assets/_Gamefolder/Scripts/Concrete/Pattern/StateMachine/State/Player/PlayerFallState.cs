using UnityEngine;

namespace GameGuruDevChallange.Patterns.StateMachine
{
    public class PlayerFallState : BaseStateWithAnimator
    {
        Rigidbody _rigidbody;

        public PlayerFallState(Animator animator, string animName, Rigidbody rigidbody) : base(animator, animName)
        {
            _rigidbody = rigidbody;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Falling");
            PushPlayer();
        }

        void PushPlayer()
        {
            _rigidbody.useGravity = true;
            _rigidbody.AddForce(Vector3.forward * 3f, ForceMode.Impulse);
        }
    }
}