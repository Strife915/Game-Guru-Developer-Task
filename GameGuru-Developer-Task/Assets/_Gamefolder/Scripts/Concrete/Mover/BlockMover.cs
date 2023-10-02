using DG.Tweening;
using GameGuruDevChallange.Abstract.Movers;
using UnityEngine;

namespace GameGuruDevChallange.Mover
{
    public class BlockMover : IMover
    {
        Tween _moveTween;
        public IMoverAttributes MoverAttributes { get; private set; }

        public BlockMover(IMoverAttributes moverAttributes)
        {
            MoverAttributes = moverAttributes;
        }


        public void Move(Transform transformToMove, Vector3 targetPosition)
        {
            _moveTween?.Kill();

            _moveTween = transformToMove.DOMoveX(targetPosition.x, MoverAttributes.MoveSpeed)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.Linear);
        }

        public void StopMovement()
        {
            _moveTween?.Kill();
        }
    }
}