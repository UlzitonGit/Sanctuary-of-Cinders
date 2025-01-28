using StarterAssets;
using UnityEngine;

public class TreeZone : MonoBehaviour
{
    [SerializeField] private CuttingTreeMiniGame _miniGame;
    [SerializeField] private ThirdPersonController _character;
    [SerializeField] private GameObject _treeCuttingPanel;
    private int _treeHP = 10;
    void Start()
    {
        
    }
    public void GetDamage(int damage)
    {
        _treeHP -= damage;
        if (_treeHP <= 0)
        {
            _character.LockCameraPosition = false;
            _treeCuttingPanel.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _miniGame.CurrentTree = gameObject.GetComponent<TreeZone>();
            _character.LockCameraPosition = true;
            _treeCuttingPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _character.LockCameraPosition = false;
            _treeCuttingPanel.SetActive(false);
        }
    }
}
