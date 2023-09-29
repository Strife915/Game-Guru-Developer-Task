using GameGuruDevChallange.Abstract.Spawners;
using UnityEngine;

namespace GameGuruDevChallange.Spawners
{
    public class BasicSpawner : ISpawner
    {
        readonly GameObject _blockPrefab;
        readonly Transform _spawnPoint;

        public BasicSpawner(GameObject blockPrefab, Transform spawnPoint)
        {
            _blockPrefab = blockPrefab;
            _spawnPoint = spawnPoint;
        }

        public void Spawn()
        {
            {
                Object.Instantiate(_blockPrefab, _spawnPoint.position, Quaternion.identity);
            }
        }
    }
}