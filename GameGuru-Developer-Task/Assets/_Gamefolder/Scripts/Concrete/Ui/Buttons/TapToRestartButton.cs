using GameGuruDevChallange.Managers;
using RoddGames.Uis;
using UnityEngine;

namespace GameGuruDevChallange.Uis
{
    public class TapToRestartButton : BaseButton
    {
        [SerializeField] CanvasGroupContoller _canvasGroupContoller;

        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.RestartGame();
            _canvasGroupContoller.CloseCanvas();
        }
    }
}