using Sirenix.OdinInspector;
using UnityEngine;

namespace GameGuruDevChallange.Patterns.Facade
{
    public class ClickFacade : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // _blockSplitManager.CalculateForfeit();
            }
        }

        [Button]
        void SpawnTest()
        {
        }
    }
}