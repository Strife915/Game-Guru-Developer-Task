using UnityEngine;

public interface IBlockSplitManager
{
    Transform LastBlock { get; set; }
    Transform MovingBlock { get; set; }
    void CalculateForfeit();
    void ResetLevel();
}