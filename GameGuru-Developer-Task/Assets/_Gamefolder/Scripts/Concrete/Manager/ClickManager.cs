using GameGuruDevChallange.Abstract.Managers;

namespace GameGuruDevChallange.Managers
{
    public class ClickManager : IClickManager
    {
        public IMover LastBlock { get; set; }


        public void HandleOnClick()
        {
            LastBlock?.StopMovement();
        }
    }
}