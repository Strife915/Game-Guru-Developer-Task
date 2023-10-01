using GameGuruDevChallange.Patterns.Facade;
using RoddGames.Abstracts.Patterns;
using UnityEngine;

namespace GameGuruDevChallange.Managers
{
    public class GameManager : SingletonMonoDestroy<GameManager>
    {
        [SerializeField] GameObject _clickFacadeGameObject;
        public bool IsGameEnd { get; private set; }

        void Awake()
        {
            SetSingleton(this);
        }

        public void StartGame()
        {
            _clickFacadeGameObject.SetActive(true);
            PlayerFacade.Instance.ChangePlayerToRun();
        }

        public void EndGame()
        {
            _clickFacadeGameObject.SetActive(false);
            IsGameEnd = true;
            Debug.Log("Game end");
        }
    }
}