using GameGuruDevChallange.Abstract.Movers;
using GameGuruDevChallange.Mover;
using GameGuruDevChallange.ScriptableObjects;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] MoverAttributesSo _moverAttributesSo;
    IMoverAttributes _moverAttributes => _moverAttributesSo;
    IMover _mover;
    public IMover Mover => _mover;

    void Awake()
    {
        _mover = new StackMover(_moverAttributesSo);
    }

    void Start()
    {
        Vector3 currentPosition = transform.position;
        bool isLeftBlock = currentPosition.x < 0;
        Vector3 targetPosition = currentPosition;

        targetPosition.x = isLeftBlock ? 10 : -10;

        _mover.Move(transform, targetPosition);
    }
}