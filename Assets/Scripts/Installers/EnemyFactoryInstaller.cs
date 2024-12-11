using UnityEngine;
using Zenject;

public class EnemyFactoryInstaller : MonoInstaller
{
    [SerializeField] private EnemiesSpawnerSystem _enemiesSpawnerSystem;

    public override void InstallBindings()
    {
        Container.Bind<EnemyFactory>().AsSingle();
        Container.Bind<EnemiesSpawnerSystem>().FromInstance(_enemiesSpawnerSystem).AsSingle();
    }
}
