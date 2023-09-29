using GameGuruDevChallange.Managers;
using RoddGames.Uis;
using UnityEngine;

namespace GameGuruDevChallange.Uis
{
    public class TapToStartButton : BaseButton
    {
        CanvasGroup _canvasGroup;

        void Start()
        {
            _canvasGroup = GetComponentInParent<CanvasGroup>();
        }

        protected override void HandleOnButtonClicked()
        {
            CloseCanvas();
            GameManager.Instance.StartGame();
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