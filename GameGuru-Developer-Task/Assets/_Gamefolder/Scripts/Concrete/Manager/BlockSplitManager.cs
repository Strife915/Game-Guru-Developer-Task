using GameGuruDevChallange.Managers;
using GameGuruDevChallange.Patterns.Facade;
using UnityEngine;

public class BlockSplitManager : IBlockSplitManager
{
    public Transform LastBlock { get; set; }
    public Transform MovingBlock { get; set; }
    float _tolarance = .3f;

    public void CalculateForfeit()
    {
        SplitBlock();
    }

    void SplitBlock()
    {
        float overflowAmount = MovingBlock.position.x - LastBlock.position.x;
        if (Mathf.Abs(overflowAmount) > LastBlock.localScale.x)
        {
            GameManager.Instance.EndGame();

            return;
        }

        if (Mathf.Abs(overflowAmount) < _tolarance)
        {
            MovingBlock.position = new Vector3(LastBlock.position.x, LastBlock.position.y, MovingBlock.position.z);
            ClickFacade.Instance.SetCurrentBlockSize(MovingBlock.localScale.x);
            return;
        }

        Debug.Log("Last object pos " + LastBlock.position);
        Debug.Log("Moving object pos " + MovingBlock.position);
        Debug.Log("Overflow Amount: " + overflowAmount);

        float newSize = LastBlock.localScale.x - Mathf.Abs(overflowAmount);
        float newPositionX = LastBlock.transform.position.x + (overflowAmount / 2);


        MovingBlock.localScale = new Vector3(Mathf.Abs(newSize), MovingBlock.localScale.y, MovingBlock.localScale.z);
        MovingBlock.position = new Vector3(newPositionX, MovingBlock.position.y, MovingBlock.position.z);

        ClickFacade.Instance.SetCurrentBlockSize(MovingBlock.localScale.x);
        if (MovingBlock.localScale.x < 0.2f)
        {
            GameManager.Instance.EndGame();
        }
    }
}