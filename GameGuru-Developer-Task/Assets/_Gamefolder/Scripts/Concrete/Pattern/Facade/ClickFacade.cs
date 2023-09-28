using GameGuruDevChallange.Abstract.Managers;
using GameGuruDevChallange.Abstract.Spawners;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameGuruDevChallange.Patterns.Facade
{
    public class ClickFacade : MonoBehaviour
    {
        [Inject] IClickManager _clickManager;
        [Inject] ISpawner _blockSpawner;
        [Inject] IBlockSplitManager _blockSplitManager;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _clickManager.HandleOnClick();
                // _blockSplitManager.CalculateForfeit();
                _blockSpawner.Spawn();
            }
        }

        [Button]
        void SpawnTest()
        {
            _blockSpawner.Spawn();
        }
    }
}