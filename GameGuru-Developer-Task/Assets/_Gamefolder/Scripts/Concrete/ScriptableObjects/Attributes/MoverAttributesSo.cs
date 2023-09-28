using UnityEngine;

namespace GameGuruDevChallange.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GameGuru/Attributes/Mover", fileName = "Mover Attributes So")]
    public class MoverAttributesSo : ScriptableObject, IMoverAttributes
    {
        [SerializeField] float _moveSpeed;
        public float MoveSpeed => _moveSpeed;
    }
}