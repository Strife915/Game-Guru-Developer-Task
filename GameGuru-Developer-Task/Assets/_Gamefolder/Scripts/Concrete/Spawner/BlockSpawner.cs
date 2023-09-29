using GameGuruDevChallange.Abstract.Spawners;
using GameGuruDevChallange.Patterns.Facade;
using UnityEngine;

namespace GameGuruDevChallange.Spawners
{
    public class BlockSpawner : MonoBehaviour, ISpawner
    {
        [SerializeField] GameObject _blockPrefab;
        [SerializeField] float _offset = 10f;
        [SerializeField] Transform _spawnPoint, _firstBlockTransform;
        Transform _lastBlockTransform;
        float _prefabLength;
        bool _isRight;
        public int SpawnCount { get; private set; }

        void Awake()
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
                ClickFacade.Instance.SetBlockStoperBlock(block.Mover);
                if (_lastBlockTransform == null)
                    ClickFacade.Instance.SetSplitManagerBlocks(_firstBlockTransform, block.transform);
                else
                {
                    ClickFacade.Instance.SetSplitManagerBlocks(_lastBlockTransform, block.transform);
                }

                block.transform.position = forwardSpawnPosition;

                _spawnPoint.position = new Vector3(0, 0, _spawnPoint.position.z);
                _isRight = !_isRight;
                _lastBlockTransform = block.transform;
                SpawnCount++;
            }
            else
            {
                Debug.LogError("Prefab is not set!");
            }
        }
    }
}