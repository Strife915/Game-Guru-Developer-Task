namespace GameGuruDevChallange.Abstract.Managers
{
    public interface IClickManager
    {
        IMover LastBlock { get; set; }
        void HandleOnClick();
    }
}