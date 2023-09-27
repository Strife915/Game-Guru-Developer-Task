using GameGuruDevChallange.Abstract.Spawners;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class StackSpawnController : MonoBehaviour
{
    [Inject] ISpawner _stackSpawner;

    [Button]
    void Spawn()
    {
        _stackSpawner.Spawn();
    }
}