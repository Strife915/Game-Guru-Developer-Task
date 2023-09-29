using GameGuruDevChallange.Abstract.Spawners;
using GameGuruDevChallange.Patterns.Facade;
using RoddGames.Abstracts.Patterns;
using UnityEngine;

namespace GameGuruDevChallange.Managers
{
    public class GameManager : SingletonMonoDestroy<GameManager>
    {
        [SerializeField] GameObject _clickFacadeGameObject;

        void Awake()
        {
            SetSingleton(this);
        }

        public void StartGame()
        {
            _clickFacadeGameObject.SetActive(true);
        }
    }
}