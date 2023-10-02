using GameGuruDevChallange.Patterns.Facade;
using UnityEngine;

public class PlayerMoveTarget : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerController playerFacade)) return;
        playerFacade.ChangePlayerToIdleState();
    }

    public void ChangePosition(Vector3 newPosition)
    {
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }
}