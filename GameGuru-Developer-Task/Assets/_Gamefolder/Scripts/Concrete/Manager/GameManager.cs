using GameGuruDevChallange.Abstract.Spawners;
using UnityEngine;
using Zenject;

namespace GameGuruDevChallange.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Inject] ISpawner _blockSpawner;

        void StartGame()
        {
            _blockSpawner.Spawn();
        }
    }
}