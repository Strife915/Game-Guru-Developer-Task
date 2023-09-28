using UnityEngine;

public interface IMover
{
    IMoverAttributes MoverAttributes { get; }
    void Move(Transform transformToMove, Vector3 targetPosition);
    void StopMovement();
}