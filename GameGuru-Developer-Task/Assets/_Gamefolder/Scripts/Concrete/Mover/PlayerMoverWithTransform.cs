using GameGuruDevChallange.Abstract.Movers;
using UnityEngine;

public class PlayerMover : IMover
{
    public IMoverAttributes MoverAttributes { get; }

    public PlayerMover(IMoverAttributes moverAttributes)
    {
        MoverAttributes = moverAttributes;
    }

    public void Move(Transform transformToMove, Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transformToMove.position).normalized;
        transformToMove.position += MoverAttributes.MoveSpeed * Time.deltaTime * direction;
    }

    public void StopMovement()
    {
    }
}