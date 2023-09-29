using GameGuruDevChallange.Abstract.Spawners;
using UnityEngine;

namespace GameGuruDevChallange.Managers
{
    public class GameManager : MonoBehaviour
    {
        ISpawner _blockSpawner;

        public void StartGame()
        {
            _blockSpawner.Spawn();
        }
    }
}