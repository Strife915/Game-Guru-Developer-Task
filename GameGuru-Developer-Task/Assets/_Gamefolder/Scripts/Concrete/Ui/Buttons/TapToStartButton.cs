using GameGuruDevChallange.Managers;
using RoddGames.Uis;
using UnityEngine;

namespace GameGuruDevChallange.Uis
{
    public class TapToStartButton : BaseButton
    {
        [SerializeField] CanvasGroupContoller _canvasGroupContoller;

        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.StartGame();
            _canvasGroupContoller.CloseCanvas();
        }
    }
}