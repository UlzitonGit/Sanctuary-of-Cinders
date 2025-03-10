using System.Collections;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using Zenject;

public class TreeZone : MiniGames
{
    [SerializeField] private CuttingTreeMiniGame _miniGame;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _checkPanel;   
    [SerializeField] private GameObject _treeCuttingPanel;
    private Animator _anim;
    private BoxCollider _boxCollider;  
    private int _treeHP = 10;
    private bool _isStarted = false;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
    }
    [Inject]
    protected override void Construct(ThirdPersonController thirdPersonController, CinemachineVirtualCamera camera, ResourcesMananger manager)
    {
        base.Construct(thirdPersonController, camera, manager);
    }
    public void GetDamage(int damage)
    {
        _treeHP -= damage;
        if (_treeHP <= 0)
        {
            _controller.enabled = true;
            _controller.LockCameraPosition = false;
            _treeCuttingPanel.SetActive(false);
            _gamePanel.SetActive(false);
            _isStarted = false;
            _mananger.AddWood(Random.Range(6, 10));
            _anim.SetTrigger("Cutted");
            _boxCollider.enabled = false;
            StartCoroutine(Raising());
            //Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !_isStarted)
        {         
            _gamePanel.SetActive(true);
            _checkPanel.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                _controller.enabled = false;
                _isStarted = true;
                _checkPanel.SetActive(false);               
                _treeCuttingPanel.SetActive(true);
                _miniGame.CanAttack = true;
                _miniGame.CurrentTree = gameObject.GetComponent<TreeZone>();
                _controller.LockCameraPosition = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _controller.enabled = true;
            _controller.LockCameraPosition = false;
            _gamePanel.SetActive(false);
            _treeCuttingPanel.SetActive(false);
        }
    }
    IEnumerator Raising()
    {
        yield return new WaitForSeconds(Random.Range(10, 15));
        _anim.SetTrigger("Raise");
        _treeHP = 10;
        _boxCollider.enabled = true;
    }
}
