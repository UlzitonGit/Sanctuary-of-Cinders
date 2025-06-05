using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MiniGames : MonoBehaviour
{
    protected CinemachineVirtualCamera _camera;
    protected ThirdPersonController _controller;
    protected ResourcesMananger _mananger;
    protected TutorialMananger _tutorialMananger;
    protected SoundsPlayer _soundMananger;
    virtual protected void Construct(ThirdPersonController thirdPersonController, CinemachineVirtualCamera camera, ResourcesMananger manager, TutorialMananger tutorialMananger, SoundsPlayer soundMananger)
    {
        _controller = thirdPersonController;
        _camera = camera;
        _tutorialMananger = tutorialMananger;
        _mananger = manager;
        _soundMananger = soundMananger;
        
        Debug.Log("binded");
    }
}
