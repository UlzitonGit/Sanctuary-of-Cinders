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
    virtual protected void Construct(ThirdPersonController thirdPersonController, CinemachineVirtualCamera camera, ResourcesMananger manager, TutorialMananger tutorialMananger)
    {
        _controller = thirdPersonController;
        _camera = camera;
        _tutorialMananger = tutorialMananger;
        _mananger = manager;
        
        Debug.Log("binded");
    }
}
