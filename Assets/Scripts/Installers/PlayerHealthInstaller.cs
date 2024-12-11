using UnityEngine;
using Zenject;

public class PlayerHealthInstaller : MonoInstaller
{
    [SerializeField] private PlayerHealth _playerHealth;

    public override void InstallBindings()
    {
        Container.Bind<PlayerHealth>().FromInstance(_playerHealth).AsSingle();
    }
}

