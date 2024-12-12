using UnityEngine;
using Zenject;

public class PlayerAmmoInstaller : MonoInstaller
{
    [SerializeField] private PlayerAmmoSystem _playerAmmoSystem;

    public override void InstallBindings()
    {
        Container.Bind<PlayerAmmoSystem>().FromInstance(_playerAmmoSystem).AsSingle();
    }
}
