using System;
using Cysharp.Threading.Tasks;
using GameGuruDevChallange.Enums;
using GameGuruDevChallange.Patterns;
using UnityEngine;

namespace GameGuruDevChallange.Managers
{
    public class FallingBlock : MonoBehaviour
    {
        async void Start()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(2));
            BlockDictionaryManager.Instance.GetPoolByType(BlockType.FallingBlock).ReturnObjectToPool(gameObject);
        }
    }
}