using Cinemachine;
using StarterAssets;
using Zenject;
using UnityEngine;

public class GameplaySceneIsntaller : MonoInstaller
{
    [SerializeField] private ThirdPersonController _tpc;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private ResourcesMananger _resourcesMananger;
    [SerializeField] private EmployeeBuyMananger _employeeBuyMananger;
    [SerializeField] private EmployeeMananger _employeeMananger;
    [SerializeField] private UpgradeMananger _upgradeMananger;
    [SerializeField] private TutorialMananger _tutorialMananger;
    [SerializeField] private SavesMananger _savesMananger;
    [SerializeField] private SoundsPlayer _soundsPlayer;
    public override void InstallBindings()
    {
        Container.Bind<ThirdPersonController>().FromInstance(_tpc)
            .AsSingle();
        Container.Bind<CinemachineVirtualCamera>().FromInstance(_camera)
            .AsSingle();
        Container.Bind<ResourcesMananger>().FromInstance(_resourcesMananger)
            .AsSingle();
        Container.Bind<EmployeeBuyMananger>().FromInstance(_employeeBuyMananger)
            .AsSingle();
        Container.Bind<EmployeeMananger>().FromInstance(_employeeMananger)
            .AsSingle();
        Container.Bind<UpgradeMananger>().FromInstance(_upgradeMananger)
         .AsSingle();
        Container.Bind<TutorialMananger>().FromInstance(_tutorialMananger)
            .AsSingle();
        Container.Bind<SavesMananger>().FromInstance(_savesMananger)
            .AsSingle();
        Container.Bind<SoundsPlayer>().FromInstance(_soundsPlayer)
            .AsSingle();
    }

}
