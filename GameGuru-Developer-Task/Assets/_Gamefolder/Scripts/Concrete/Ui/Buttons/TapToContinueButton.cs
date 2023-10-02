using GameGuruDevChallange.Managers;
using RoddGames.Uis;
using UnityEngine;

namespace GameGuruDevChallange.Uis
{
    public class TapToContinueButton : BaseButton
    {
        [SerializeField] CanvasGroupContoller _canvasGroupContoller;

        protected override void HandleOnButtonClicked()
        {
            _canvasGroupContoller.CloseCanvas();
            GameManager.Instance.ResumeGame();
        }
    }
}