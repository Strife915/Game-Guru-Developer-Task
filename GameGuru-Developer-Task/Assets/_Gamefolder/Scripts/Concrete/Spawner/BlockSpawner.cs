using System;
using GameGuruDevChallange.Abstract.Spawners;
using UnityEngine;

namespace GameGuruDevChallange.Spawners
{
    public class BlockSpawner : MonoBehaviour, ISpawner
    {
        [SerializeField] GameObject _blockPrefab;
        [SerializeField] float _offset = 10f;
        [SerializeField] Transform _spawnPoint;
        float _prefabLength;
        bool _isRight;

        void Start()
        {
            var prefabRenderer = _blockPrefab.GetComponentInChildren<MeshRenderer>();
            _prefabLength = prefabRenderer != null ? prefabRenderer.bounds.size.z : 0f;
        }

        public void Spawn()
        {
            if (_blockPrefab != null)
            {
                var spawnPosition = _isRight
                    ? _spawnPoint.position + Vector3.right * _offset
                    : _spawnPoint.position - Vector3.right * _offset;

                var forwardSpawnPosition = spawnPosition + Vector3.forward * _prefabLength;

                _spawnPoint.position = forwardSpawnPosition;
                StackController block = Instantiate(_blockPrefab).GetComponent<StackController>();
                block.transform.position = forwardSpawnPosition;

                _spawnPoint.position = new Vector3(0, 0, _spawnPoint.position.z);
                _isRight = !_isRight;
            }
            else
            {
                Debug.LogError("Prefab is not set!");
            }
        }
    }
}