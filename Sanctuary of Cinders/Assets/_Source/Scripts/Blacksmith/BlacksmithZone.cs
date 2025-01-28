using Cinemachine;
using StarterAssets;
using UnityEngine;

public class BlacksmithZone : MonoBehaviour
{
    [SerializeField] private HammerPunch _hammer;
    [SerializeField] private Transform _forge;
    [SerializeField] private GameObject _blackSmithStone;
    [SerializeField] private GameObject _blackSmithSword;
    [SerializeField] private GameObject _blackSmithHammer;
    [SerializeField] private Transform _blacksmith;
    [SerializeField] private Transform _playerController;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private ThirdPersonController _controller;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _panelBlackSmith;
    bool _isForging = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !_isForging)
        {
            _panel.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                _isForging = true;
                _panel.SetActive(false);
                _panelBlackSmith.SetActive(true);
                _controller.LockCameraPosition = true;
                _controller.enabled = false;
                _camera.Follow =_forge.transform;
            }
          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            _panel.SetActive(false);
        }
    }
    public void StartBlacksmith()
    {
        //_isForging = false;
        //_panel.SetActive(false);
        _hammer.canAttack = true;
        _panelBlackSmith.SetActive(false);
        _camera.Follow = _blacksmith.transform;
   
        _blackSmithSword.SetActive(true);
        _blackSmithHammer.SetActive(true);
    }
    public void CloseForging()
    {
        _isForging = false;
        _panel.SetActive(true);
        _panelBlackSmith.SetActive(false);
        _controller.LockCameraPosition = false;
        _controller.enabled = true;
        _camera.Follow = _playerController.transform;
       
        _blackSmithSword.SetActive(false);
        _blackSmithHammer.SetActive(false);
    }
}
