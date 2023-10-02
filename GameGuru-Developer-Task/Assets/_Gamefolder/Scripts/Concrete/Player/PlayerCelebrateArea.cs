using GameGuruDevChallange.Patterns.Facade;
using UnityEngine;

public class PlayerCelebrateArea : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerFacade playerFacade)) return;
        playerFacade.ChangePlayerToCelebrate();
    }
}