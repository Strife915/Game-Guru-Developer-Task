using UnityEngine;

namespace GameGuruDevChallange.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GameGuru/Containers/Material", fileName = "Material Container")]
    public class MaterialContainerSo : ScriptableObject
    {
        [SerializeField] Material[] _materials;

        public Material[] Materials => _materials;
    }
}