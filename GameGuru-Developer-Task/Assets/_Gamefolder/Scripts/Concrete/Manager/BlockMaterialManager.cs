using System;
using GameGuruDevChallange.ScriptableObjects;
using RoddGames.Abstracts.Patterns;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameGuruDevChallange.Managers
{
    public class BlockMaterialManager : SingletonMonoDestroy<BlockMaterialManager>
    {
        [SerializeField] MaterialContainerSo _materialContainerSo;
        int _lastMaterialIndex = -1;

        void Awake()
        {
            SetSingleton(this);
        }

        public Material GetRandomMaterial()
        {
            int number = GetRandomMaterialIndex();
            return _materialContainerSo.Materials[number];
        }

        public int GetRandomMaterialIndex()
        {
            if (_materialContainerSo == null || _materialContainerSo.Materials.Length == 0)
            {
                Debug.LogError("Material container is empty");
                return -1;
            }

            int randomIndex = Random.Range(0, _materialContainerSo.Materials.Length);
            while (randomIndex == _lastMaterialIndex)
            {
                randomIndex = Random.Range(0, _materialContainerSo.Materials.Length);
            }

            _lastMaterialIndex = randomIndex;

            return randomIndex;
        }
    }
}