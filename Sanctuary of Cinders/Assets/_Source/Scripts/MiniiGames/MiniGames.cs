using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MiniGames : MonoBehaviour
{
    protected CinemachineVirtualCamera _camera;
    protected ThirdPersonController _controller;
    protected ResourcesMananger _mananger;
    virtual protected void Construct(ThirdPersonController thirdPersonController, CinemachineVirtualCamera camera, ResourcesMananger manager)
    {
        _controller = thirdPersonController;
        _camera = camera;
        _mananger = manager;
        Debug.Log("binded");
    }
}
