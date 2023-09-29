using GameGuruDevChallange.Abstract.Movers;

public class BlockStoper : IBlockStoper
{
    public IMover MovingBlock { get; set; }

    public void Stop()
    {
        MovingBlock.StopMovement();
    }
}