using GameGuruDevChallange.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace GameGuruDevChallange.Installers
{
    public class MoverAttributesInstaler : MonoInstaller
    {
        [SerializeField] MoverAttributesSo _stackMoverAttributes;

        public override void InstallBindings()
        {
            Container.Bind<IMoverAttributes>().FromInstance(_stackMoverAttributes).AsSingle();
        }
    }
}