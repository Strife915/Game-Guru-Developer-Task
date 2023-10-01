using GameGuruDevChallange.Patterns.Facade;
using UnityEngine;

public class PlayerMoveTarget : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerFacade playerFacade)) return;
        playerFacade.ChangePlayerToIdleState();
    }
}