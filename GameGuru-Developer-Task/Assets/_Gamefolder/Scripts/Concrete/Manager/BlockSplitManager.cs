using UnityEngine;

public class BlockSplitManager : IBlockSplitManager
{
    public void CalculateForfeit(float staticBlockPos, float dynamicBlockPos)
    {
        Debug.Log(staticBlockPos - dynamicBlockPos);
    }
}