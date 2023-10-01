using GameGuruDevChallange.Patterns.Facade;
using RoddGames.Abstracts.Patterns;
using RoddGames.ScriptableObjects;
using UnityEngine;

namespace GameGuruDevChallange.Managers
{
    public class GameManager : SingletonMonoDestroy<GameManager>
    {
        [SerializeField] GameObject _clickFacadeGameObject;
        [SerializeField] GameEvent _gameRestartEvent, _gameEndEvent;
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
        }

        public void PublishGameEnd()
        {
            _gameEndEvent.InvokeEvents();
        }

        public void RestartGame()
        {
            _gameRestartEvent.InvokeEvents();
        }
    }
}