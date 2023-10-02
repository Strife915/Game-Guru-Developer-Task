using System.Collections.Generic;
using GameGuruDevChallange.Enums;
using GameGuruDevChallange.Patterns;
using RoddGames.Abstracts.Patterns;
using UnityEngine;

namespace GameGuruDevChallange.Managers
{
    public class BlockPoolDictionaryManager : SingletonMonoDestroy<BlockPoolDictionaryManager>
    {
        [SerializeField] BlockPool _blockPool;
        [SerializeField] FallingBlockPool _fallingBlockPool;
        Dictionary<BlockType, BasicGameObjectPool> _blockPools;

        void Awake()
        {
            SetSingleton(this);
            _blockPools = new Dictionary<BlockType, BasicGameObjectPool>();
            _blockPools.Add(BlockType.MovingBlock, _blockPool);
            _blockPools.Add(BlockType.FallingBlock, _fallingBlockPool);
        }

        public BasicGameObjectPool GetPoolByType(BlockType blockType)
        {
            return _blockPools[blockType];
        }
    }
}