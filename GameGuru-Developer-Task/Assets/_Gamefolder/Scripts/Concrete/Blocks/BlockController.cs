using GameGuruDevChallange.Abstract.Movers;
using GameGuruDevChallange.Managers;
using GameGuruDevChallange.Mover;
using GameGuruDevChallange.ScriptableObjects;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] MoverAttributesSo _moverAttributesSo;
    MeshRenderer _meshRenderer;
    IMoverAttributes _moverAttributes => _moverAttributesSo;
    IMover _mover;
    public IMover Mover => _mover;

    void Awake()
    {
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
        _mover = new BlockMover(_moverAttributesSo);
    }

    void OnEnable()
    {
        _meshRenderer.material = BlockMaterialManager.Instance.GetRandomMaterial();
    }

    void Start()
    {
        Vector3 currentPosition = transform.position;
        bool isLeftBlock = currentPosition.x < 0;
        Vector3 targetPosition = currentPosition;

        targetPosition.x = isLeftBlock ? 7 : -7;

        _mover.Move(transform, targetPosition);
    }
}