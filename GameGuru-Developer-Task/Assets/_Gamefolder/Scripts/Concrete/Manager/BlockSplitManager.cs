using UnityEngine;

public class BlockSplitManager : IBlockSplitManager
{
    public Transform LastBlock { get; set; }
    public Transform MovingBlock { get; set; }


    public void CalculateForfeit()
    {
        SplitBlock();
    }

    void SplitBlock()
    {
        Vector3 size1 = LastBlock.GetComponentInChildren<Renderer>().bounds.size;
        Vector3 size2 = MovingBlock.GetComponentInChildren<Renderer>().bounds.size;

        Vector3 position1 = LastBlock.transform.position;
        Vector3 position2 = MovingBlock.transform.position;

        float overflowAmount = (position2.x + (size2.x / 2)) - (position1.x + (size1.x / 2));

        Debug.Log("Overflow Amount: " + overflowAmount);

        Vector3 newScale2 = MovingBlock.transform.localScale - new Vector3(Mathf.Abs(overflowAmount), 0, 0);
        MovingBlock.transform.localScale = newScale2;

        float newPositionX = position1.x;
        if (overflowAmount > 0)
        {
            newPositionX += (size1.x / 2) + (newScale2.x / 2);
        }
        else
        {
            newPositionX -= (size1.x / 2) + (newScale2.x / 2);
        }

        MovingBlock.transform.position = new Vector3(newPositionX / 2, position2.y, position2.z);
    }
}