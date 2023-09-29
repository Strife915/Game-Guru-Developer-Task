using UnityEngine;

namespace GameGuruDevChallange.Abstract.Movers
{
    public interface IMover
    {
        IMoverAttributes MoverAttributes { get; }
        void Move(Transform transformToMove, Vector3 targetPosition);
        void StopMovement();
    }
}