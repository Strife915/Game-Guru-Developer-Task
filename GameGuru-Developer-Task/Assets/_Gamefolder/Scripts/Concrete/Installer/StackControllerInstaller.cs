using GameGuruDevChallange.Mover;
using Zenject;

namespace GameGuruDevChallange.Installers
{
    public class StackControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMover>().To<StackMover>().AsTransient();
        }
    }
}