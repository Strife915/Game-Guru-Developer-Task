namespace GameGuruDevChallange.Abstract.Movers
{
    public interface IBlockStoper
    {
        IMover MovingBlock { get; set; }
        void Stop();
    }
}