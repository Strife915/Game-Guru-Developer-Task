using GameGuruDevChallange.Abstract.Movers;
using GameGuruDevChallange.Abstract.Spawners;
using GameGuruDevChallange.Managers;
using GameGuruDevChallange.Spawners;
using RoddGames.Abstracts.Patterns;
using UnityEngine;

namespace GameGuruDevChallange.Patterns.Facade
{
    public class ClickFacade : SingletonMonoDestroy<ClickFacade>
    {
        [SerializeField] BlockSpawner _concreteBlockSpawner;
        [SerializeField] PlayerMoveTarget _playerMoveTarget;
        [SerializeField] Transform _victoryPlatform;
        ISpawner _blockSpawner => _concreteBlockSpawner;
        IBlockSplitManager _blockSplitManager;
        IBlockStoper _blockStoper;
        IBlockSizeHolder _blockSizeHolder;
        Vector3 _initialPlayerMoveTarget;


        void Awake()
        {
            SetSingleton(this);
            _initialPlayerMoveTarget = _playerMoveTarget.transform.position;
            _blockSplitManager = new BlockSplitManager();
            _blockStoper = new BlockStoper();
            _blockSizeHolder = new BlockSizeHolder();
        }

        void OnEnable()
        {
            _blockSpawner.Spawn();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _blockStoper.Stop();
                _blockSplitManager.CalculateForfeit();
                if (!GameManager.Instance.IsGameEnd && !GameManager.Instance.IsLevelComplate)
                {
                    PlayerFacade.Instance.ChangePlayerToRun();
                    _blockSpawner.Spawn();
                }
            }
        }

        public void SetVictoryPlatformPosition(Vector3 newPosition)
        {
            _victoryPlatform.position = newPosition;
        }

        public void SetPlayerNewMoveTarget(Vector3 newPosition)
        {
            _playerMoveTarget.ChangePosition(newPosition);
        }

        public void SetPlayerMoveTargetToCelebrateArea()
        {
            Vector3 currentPlayerMoveTargetPos = _playerMoveTarget.transform.position;
            _playerMoveTarget.transform.position = new Vector3(currentPlayerMoveTargetPos.x, currentPlayerMoveTargetPos.y, _victoryPlatform.transform.position.z);
            PlayerFacade.Instance.ChangePlayerToRun();
            _blockSplitManager.LastBlock = _victoryPlatform;
        }

        public void ResetPlayerMoveTarget()
        {
            _playerMoveTarget.transform.position = _initialPlayerMoveTarget;
            _blockSplitManager.ResetLevel();
        }


        public void SetSplitManagerBlocks(Transform lastBlock, Transform movingBlock)
        {
            _blockSplitManager.LastBlock = lastBlock;
            _blockSplitManager.MovingBlock = movingBlock;
        }

        public void SetBlockStoperBlock(IMover mover)
        {
            _blockStoper.MovingBlock = mover;
        }

        public void SetCurrentBlockSize(float currentScale)
        {
            _blockSizeHolder.CurrentScale = currentScale;
        }

        public float GetCurrentBlockSize()
        {
            return _blockSizeHolder.CurrentScale;
        }
    }
}