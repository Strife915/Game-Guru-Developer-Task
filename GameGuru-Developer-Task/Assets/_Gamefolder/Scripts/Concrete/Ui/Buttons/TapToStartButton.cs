using GameGuruDevChallange.Managers;
using RoddGames.Uis;
using UnityEngine;
using Zenject;

namespace GameGuruDevChallange.Uis
{
    public class TapToStartButton : BaseButton
    {
        [Inject] GameManager _gameManager;
        CanvasGroup _canvasGroup;

        void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        protected override void HandleOnButtonClicked()
        {
            _gameManager.StartGame();
            CloseCanvas();
        }

        void CloseCanvas()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        void OpenCanvas()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}