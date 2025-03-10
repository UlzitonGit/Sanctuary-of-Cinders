using Cinemachine;
using StarterAssets;
using Zenject;
using UnityEngine;

public class GameplaySceneIsntaller : MonoInstaller
{
    [SerializeField] private ThirdPersonController _tpc;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private ResourcesMananger _resourcesMananger;
    public override void InstallBindings()
    {
        Container.Bind<ThirdPersonController>().FromInstance(_tpc)
            .AsSingle();
        Container.Bind<CinemachineVirtualCamera>().FromInstance(_camera)
          .AsSingle();
        Container.Bind<ResourcesMananger>().FromInstance(_resourcesMananger)
         .AsSingle();
    }
}
