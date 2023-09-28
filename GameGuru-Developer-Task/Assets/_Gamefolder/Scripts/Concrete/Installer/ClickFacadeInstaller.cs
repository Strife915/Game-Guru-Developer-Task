using GameGuruDevChallange.Abstract.Managers;
using GameGuruDevChallange.Abstract.Spawners;
using GameGuruDevChallange.Managers;
using GameGuruDevChallange.Spawners;
using Zenject;

namespace GameGuruDevChallange.Installers
{
    public class ClickFacadeInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IClickManager>().To<ClickManager>().AsSingle();
            Container.Bind<ISpawner>().To<StackSpawner>().AsSingle();
            Container.Bind<IBlockSplitManager>().To<BlockSplitManager>().AsSingle();
        }
    }
}