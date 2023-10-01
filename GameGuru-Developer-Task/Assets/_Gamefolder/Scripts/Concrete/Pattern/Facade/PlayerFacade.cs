using GameGuruDevChallange.Managers;
using UnityEngine;

namespace GameGuruDevChallange.Patterns.Facade
{
    public class PlayerFacade : MonoBehaviour
    {
        [SerializeField] Animator _playerAnimator;
        PlayerStateManager _stateManager;

        void Awake()
        {
            _stateManager = new PlayerStateManager(_playerAnimator);
        }

        void Update()
        {
            _stateManager.Update();
        }
    }
}