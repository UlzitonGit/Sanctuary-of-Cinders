using Cinemachine;
using StarterAssets;
using TMPro;
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
    [SerializeField] private GameObject _sellPanel;
    [SerializeField] private TextMeshProUGUI _woodCostText;
    [SerializeField] private TextMeshProUGUI _ironCostText;
    [SerializeField] private int _ironCost = 5;
    [SerializeField] private int _woodCost = 10;
    [SerializeField] private TextMeshProUGUI _sellCostText;

    [SerializeField] public int SwordCost = 100;

    private ResourcesMananger _mananger;
    private bool _isForging = false;
    private void Start()
    {
        _mananger = FindAnyObjectByType<ResourcesMananger>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !_isForging)
        {
            _panel.SetActive(true);
            _woodCostText.text = _woodCost.ToString();
            _ironCostText.text = _ironCost.ToString();
            if (Input.GetKey(KeyCode.E) && _mananger.Wood >= _woodCost && _mananger.Iron >= _ironCost)
            {
                _mananger.AddIron(_ironCost * -1);
                _mananger.AddWood(_woodCost * -1);
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
    public void OpenSellMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        _sellPanel.SetActive(true);
        _sellCostText.text = "SELL: +" + SwordCost.ToString() + " rice";
    }
    public void CloseSellMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        _sellPanel.SetActive(false);
        _sellCostText.text = SwordCost.ToString();
    }
    public void KeepSword()
    {
        CloseSellMenu();
        CloseForging();
    }
    public void SellSword()
    {
        CloseSellMenu();
        _mananger.AddRice(SwordCost);
        CloseForging();
    }
}
