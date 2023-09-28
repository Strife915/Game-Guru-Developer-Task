using GameGuruDevChallange.Factories;
using UnityEngine;
using Zenject;

namespace GameGuruDevChallange.Installers
{
    public class FactoryInstaller : MonoInstaller
    {
        [SerializeField] StackController _stackControllerPrefab;

        public override void InstallBindings()
        {
            Container.BindFactory<StackController, BlockFactory>().FromComponentInNewPrefab(_stackControllerPrefab.gameObject);
        }
    }
}