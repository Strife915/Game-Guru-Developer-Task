using System.Collections.Generic;
using GameGuruDevChallange.Enums;
using GameGuruDevChallange.ScriptableObjects;
using RoddGames.Abstracts.Patterns;
using UnityEngine;

namespace GameGuruDevChallange.Managers
{
    public class SoundManager : SingletonMonoDestroy<SoundManager>, ISoundManager
    {
        [SerializeField] AudioSource _audioSource;
        [SerializeField] SoundContainerSo[] _soundContainers;
        [SerializeField] float _pitchIncrement;
        Dictionary<SoundType, AudioClip> _soundDic;
        float _initialPitch;

        void Awake()
        {
            SetSingleton(this);
            _soundDic = new Dictionary<SoundType, AudioClip>();
            foreach (var soundContainerSo in _soundContainers)
            {
                _soundDic.Add(soundContainerSo.AudioType, soundContainerSo.AudioClip);
            }
        }

        void Start()
        {
            _initialPitch = _audioSource.pitch;
        }

        void ResetPitch()
        {
            _audioSource.pitch = _initialPitch;
        }

        public void SingleShot(SoundType soundType)
        {
            _audioSource.clip = _soundDic[soundType];
            ResetPitch();
            _audioSource.Play();
        }

        public void CombomPlay(SoundType soundType)
        {
            _audioSource.clip = _soundDic[soundType];
            _audioSource.Play();
            _audioSource.pitch += _pitchIncrement;
        }
    }
}