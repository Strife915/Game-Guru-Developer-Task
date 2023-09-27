using GameGuruDevChallange.Abstract.Spawners;
using GameGuruDevChallange.Spawners;
using UnityEngine;
using Zenject;

public class BasicSpawnerInstaller : MonoInstaller
{
    [SerializeField] GameObject _blockPrefab;
    [SerializeField] Transform _spawnPoint;

    public override void InstallBindings()
    {
        Container.Bind<ISpawner>().To<BasicSpawner>().AsSingle();
        Container.Bind<GameObject>().FromInstance(_blockPrefab).AsSingle();
        Container.Bind<Transform>().FromInstance(_spawnPoint).AsSingle();
    }
}