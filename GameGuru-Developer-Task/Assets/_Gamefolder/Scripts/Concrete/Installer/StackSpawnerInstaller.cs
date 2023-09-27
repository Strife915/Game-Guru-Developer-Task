using GameGuruDevChallange.Abstract.Spawners;
using GameGuruDevChallange.Spawners;
using UnityEngine;
using Zenject;

public class StackSpawnerInstaller : MonoInstaller
{
    [SerializeField] GameObject _blockPrefab;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] float _offset;

    public override void InstallBindings()
    {
        Container.Bind<ISpawner>().To<StackSpawner>().AsSingle();
        Container.Bind<GameObject>().FromInstance(_blockPrefab).AsSingle();
        Container.Bind<Transform>().FromInstance(_spawnPoint).AsSingle();
        Container.Bind<float>().FromInstance(_offset).AsSingle();
    }
}