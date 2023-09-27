using UnityEngine;
using Zenject;

namespace GameGuruDevChallange.Installers
{
    public class MoverInstaller : MonoInstaller<MoverInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IMover>().To<StackMover>().AsSingle();
        }
    }
    
}
