using UnityEngine;

public class BlockSplitManager : IBlockSplitManager
{
    public Transform LastBlock { get; set; }
    public Transform MovingBlock { get; set; }


    public void CalculateForfeit()
    {
        float hangover = MovingBlock.position.x - LastBlock.position.x;
        SplitBlock(hangover);
    }

    void SplitBlock(float hangover)
    {
        float newSize = LastBlock.localScale.x - Mathf.Abs(hangover);
        float fallingBlockSize = MovingBlock.localScale.x - newSize;

        float newXPosition = LastBlock.position.x + (hangover / 2);
        MovingBlock.localScale = new Vector3(newSize, MovingBlock.localScale.y, MovingBlock.localScale.z);
        MovingBlock.position = new Vector3(newXPosition, MovingBlock.position.y, MovingBlock.position.z);
    }
}