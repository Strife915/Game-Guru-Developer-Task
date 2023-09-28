using UnityEngine;
using Zenject;

public class StackController : MonoBehaviour
{
    [Inject] IMover _mover;

    void Start()
    {
        Vector3 currentPosition = transform.position;
        bool isLeftBlock = currentPosition.x < 0;
        Vector3 targetPosition = currentPosition;

        targetPosition.x = isLeftBlock ? 10f : -10f;

        _mover.Move(transform, targetPosition);
    }
}