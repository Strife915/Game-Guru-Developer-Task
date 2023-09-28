using GameGuruDevChallange.Managers;
using Zenject;

namespace GameGuruDevChallange.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}