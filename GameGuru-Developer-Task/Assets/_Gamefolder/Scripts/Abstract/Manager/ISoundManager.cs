using GameGuruDevChallange.Enums;
using UnityEngine;

namespace GameGuruDevChallange.Managers
{
    public interface ISoundManager
    {
        void SingleShot(SoundType soundType);
        void CombomPlay(SoundType soundType);
    }
}