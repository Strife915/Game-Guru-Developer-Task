using GameGuruDevChallange.Managers;
using GameGuruDevChallange.Patterns.Facade;
using UnityEngine;

public class PlayerCelebrateArea : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerFacade playerFacade)) return;
        playerFacade.ChangePlayerToCelebrate();
        GameManager.Instance.LevelComplete();
    }
}