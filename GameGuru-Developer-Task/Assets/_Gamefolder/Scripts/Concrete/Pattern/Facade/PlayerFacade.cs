using GameGuruDevChallange.Managers;
using GameGuruDevChallange.ScriptableObjects;
using RoddGames.Abstracts.Patterns;
using UnityEngine;

namespace GameGuruDevChallange.Patterns.Facade
{
    public class PlayerFacade : SingletonMonoDestroy<PlayerFacade>
    {
        [SerializeField] Animator _playerAnimator;
        [SerializeField] Rigidbody _rigidbody;
        [SerializeField] MoverAttributesSo _moverAttributesSo;
        [SerializeField] Transform _playerMoveTarget;
        PlayerStateManager _stateManager;
        Vector3 _initialPosition;
        IMoverAttributes _moverAttributes => _moverAttributesSo;

        void Awake()
        {
            _initialPosition = transform.position;
            SetSingleton(this);
            GetReference();
            _stateManager = new PlayerStateManager(_playerAnimator, _moverAttributes, _playerMoveTarget, transform, _rigidbody);
        }

        public void ChangePlayerToIdleState()
        {
            _stateManager.ChangePlayerToIdle();
        }

        public void ChangePlayerToRun()
        {
            _stateManager.ChangePlayerToRun();
        }


        void Update()
        {
            _stateManager.Update();
        }

        void OnValidate()
        {
            GetReference();
        }

        void GetReference()
        {
            if (_playerAnimator == null)
                _playerAnimator = GetComponentInChildren<Animator>();
            if (_rigidbody == null)
                _rigidbody = GetComponent<Rigidbody>();
        }

        public void ResetPlayer()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.useGravity = false;
            _stateManager.ChangePlayerToIdle();
            transform.position = _initialPosition;
        }
    }
}