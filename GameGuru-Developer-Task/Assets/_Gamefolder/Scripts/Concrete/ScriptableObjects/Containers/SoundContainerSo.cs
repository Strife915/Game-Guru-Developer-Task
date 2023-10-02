using GameGuruDevChallange.Enums;
using UnityEngine;

namespace GameGuruDevChallange.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GameGuru/Containers/Sound", fileName = "Sound Container")]
    public class SoundContainerSo : ScriptableObject
    {
        [SerializeField] AudioClip _audioClip;
        [SerializeField] SoundType _soundType;

        public AudioClip AudioClip => _audioClip;
        public SoundType AudioType => _soundType;
    }
}