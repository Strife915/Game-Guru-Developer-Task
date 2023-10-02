using GameGuruDevChallange.Enums;
using GameGuruDevChallange.Patterns.Facade;
using UnityEngine;

namespace GameGuruDevChallange.Managers
{
    public class BlockSplitManager : IBlockSplitManager
    {
        float _tolarance = .3f;
        LevelManager _levelManager;
        int _splitCount;
        public Transform LastBlock { get; set; }
        public Transform MovingBlock { get; set; }

        public BlockSplitManager()
        {
            _levelManager = new LevelManager();
        }

        public void CalculateForfeit()
        {
            float overflowAmount = MovingBlock.position.x - LastBlock.position.x;
            float direction = overflowAmount > 0 ? 1f : -1f;
            if (Mathf.Abs(overflowAmount) > LastBlock.localScale.x)
            {
                SpawnDropCube(MovingBlock.position.x, MovingBlock.localScale.x);
                BlockDictionaryManager.Instance.GetPoolByType(BlockType.MovingBlock).ReturnObjectToPool(MovingBlock.gameObject);
                GameManager.Instance.EndGame();
                return;
            }

            if (Mathf.Abs(overflowAmount) < _tolarance)
            {
                MovingBlock.position = new Vector3(LastBlock.position.x, LastBlock.position.y, MovingBlock.position.z);
                ClickFacade.Instance.SetCurrentBlockSize(MovingBlock.localScale.x);
                //This line works only this scale values (+2) value should be calculated from mesh size
                ClickFacade.Instance.SetPlayerNewMoveTarget(new Vector3(MovingBlock.position.x, MovingBlock.position.y, MovingBlock.position.z + 2));
                IncreaseSplitCount();
                CheckLevelComplete();
                return;
            }

            SplitBlock(overflowAmount, direction);
        }

        void SplitBlock(float overFlow, float direction)
        {
            float newSize = LastBlock.localScale.x - Mathf.Abs(overFlow);
            float fallingBlockSize = MovingBlock.localScale.x - newSize;
            float newPositionX = LastBlock.transform.position.x + (overFlow / 2);


            MovingBlock.localScale = new Vector3(Mathf.Abs(newSize), MovingBlock.localScale.y, MovingBlock.localScale.z);
            MovingBlock.position = new Vector3(newPositionX, MovingBlock.position.y, MovingBlock.position.z);

            float cubeEdge = MovingBlock.position.x + (newSize / 2f * direction);
            float fallingBlockXPosition = cubeEdge + fallingBlockSize / 2f * direction;
            SpawnDropCube(fallingBlockXPosition, fallingBlockSize);


            if (MovingBlock.localScale.x < 0.2f)
            {
                GameManager.Instance.EndGame();
                BlockDictionaryManager.Instance.GetPoolByType(BlockType.MovingBlock).ReturnObjectToPool(MovingBlock.gameObject);
                SpawnDropCube(MovingBlock.position.x, MovingBlock.localScale.x);
                return;
            }

            ClickFacade.Instance.SetCurrentBlockSize(MovingBlock.localScale.x);
            ClickFacade.Instance.SetPlayerNewMoveTarget(new Vector3(MovingBlock.position.x, MovingBlock.position.y, MovingBlock.position.z + 2));
            IncreaseSplitCount();
            CheckLevelComplete();
        }

        void IncreaseSplitCount()
        {
            _splitCount++;
        }

        void CheckLevelComplete()
        {
            if (_splitCount >= _levelManager.CurrentCountForSuccess)
            {
                Debug.Log("Level complete");
                GameManager.Instance.CompleteLevel();
                _levelManager.LevelUp();
                _splitCount = 0;
                ClickFacade.Instance.SetVictoryPlatformPosition(new Vector3(MovingBlock.position.x, MovingBlock.position.y, MovingBlock.position.z + MovingBlock.localScale.z));
                ClickFacade.Instance.SetPlayerMoveTargetToCelebrateArea();
                //ClickFacade.Instance.SetCurrentBlockSize();
            }
        }

        void SpawnDropCube(float fallingBlockXPosition, float fallingBlockSize)
        {
            var cube = BlockDictionaryManager.Instance.GetPoolByType(BlockType.FallingBlock).GetObjectFromPool();
            cube.gameObject.SetActive(true);
            MeshRenderer cubeMesh = cube.GetComponentInChildren<MeshRenderer>();
            cubeMesh.material = BlockMaterialManager.Instance.GetLastMaterial();
            cube.transform.localScale = new Vector3(fallingBlockSize, MovingBlock.localScale.y, MovingBlock.localScale.z);
            cube.transform.position = new Vector3(fallingBlockXPosition, MovingBlock.position.y, MovingBlock.position.z);
        }
    }
}