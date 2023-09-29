using GameGuruDevChallange.Abstract.Movers;
using GameGuruDevChallange.Abstract.Spawners;
using GameGuruDevChallange.Spawners;
using RoddGames.Abstracts.Patterns;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameGuruDevChallange.Patterns.Facade
{
    public class ClickFacade : SingletonMonoDestroy<ClickFacade>
    {
        [SerializeField] BlockSpawner _concreteBlockSpawner;
        ISpawner _blockSpawner => _concreteBlockSpawner;

        IBlockSplitManager _blockSplitManager;

        IBlockStoper _blockStoper;


        void Awake()
        {
            SetSingleton(this);
            _blockSplitManager = new BlockSplitManager();
            _blockStoper = new BlockStoper();
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
                _blockSpawner.Spawn();
            }
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

        [Button]
        void SpawnTest()
        {
        }
    }
}