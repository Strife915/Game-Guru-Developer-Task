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
        float overflowAmount = MovingBlock.position.x - LastBlock.position.x;
        float direction = overflowAmount > 0 ? 1f : -1f;
        SplitBlock(overflowAmount, direction);
    }

    void SplitBlock(float overFlow, float direction)
    {
        if (Mathf.Abs(overFlow) > LastBlock.localScale.x)
        {
            GameManager.Instance.EndGame();

            return;
        }

        if (Mathf.Abs(overFlow) < _tolarance)
        {
            MovingBlock.position = new Vector3(LastBlock.position.x, LastBlock.position.y, MovingBlock.position.z);
            ClickFacade.Instance.SetCurrentBlockSize(MovingBlock.localScale.x);
            return;
        }

        float newSize = LastBlock.localScale.x - Mathf.Abs(overFlow);
        float fallingBlockSize = MovingBlock.localScale.x - newSize;
        float newPositionX = LastBlock.transform.position.x + (overFlow / 2);


        MovingBlock.localScale = new Vector3(Mathf.Abs(newSize), MovingBlock.localScale.y, MovingBlock.localScale.z);
        MovingBlock.position = new Vector3(newPositionX, MovingBlock.position.y, MovingBlock.position.z);

        float cubeEdge = MovingBlock.position.x + (newSize / 2f * direction);
        float fallingBlockXPosition = cubeEdge + fallingBlockSize / 2f * direction;
        SpawnDropCube(fallingBlockXPosition, fallingBlockSize);
        ClickFacade.Instance.SetCurrentBlockSize(MovingBlock.localScale.x);
        if (MovingBlock.localScale.x < 0.2f)
        {
            GameManager.Instance.EndGame();
        }
    }

    void SpawnDropCube(float fallingBlockXPosition, float fallingBlockSize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(fallingBlockSize, MovingBlock.localScale.y, MovingBlock.localScale.z);
        cube.transform.position = new Vector3(fallingBlockXPosition, MovingBlock.position.y, MovingBlock.position.z);
        cube.AddComponent<Rigidbody>();
    }
}