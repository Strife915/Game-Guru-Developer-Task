using System;
using Cysharp.Threading.Tasks;
using GameGuruDevChallange.Enums;
using UnityEngine;

namespace GameGuruDevChallange.Managers
{
    public class FallingBlock : MonoBehaviour
    {
        async void OnEnable()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(2));
            BlockPoolDictionaryManager.Instance.GetPoolByType(BlockType.FallingBlock).ReturnObjectToPool(gameObject);
        }
    }
}