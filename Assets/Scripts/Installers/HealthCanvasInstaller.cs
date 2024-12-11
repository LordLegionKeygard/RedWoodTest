using UnityEngine;
using Zenject;

public class HealthCanvasInstaller : MonoInstaller
{
    [SerializeField] private Transform _healthCanvas;

    public override void InstallBindings()
    {
        Container.Bind<Transform>().FromInstance(_healthCanvas).AsSingle();
    }
}
