using GameGuruDevChallange.Patterns.Facade;
using UnityEngine;

namespace GameGuruDevChallange.Managers
{
    public class PlayerCelebrateArea : MonoBehaviour
    {
        Vector3 _initialPosition;

        void Awake()
        {
            _initialPosition = transform.position;
        }

        void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerController playerFacade)) return;
            playerFacade.ChangePlayerToCelebrate();
            GameManager.Instance.LevelComplete();
        }

        public void ResetPosition()
        {
            transform.position = _initialPosition;
        }
    }
}