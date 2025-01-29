using System.Collections;
using StarterAssets;
using UnityEngine;

public class TreeZone : MonoBehaviour
{
    [SerializeField] private CuttingTreeMiniGame _miniGame;
    [SerializeField] private ThirdPersonController _character;
    [SerializeField] private GameObject _treeCuttingPanel;
    private Animator _anim;
    private BoxCollider _boxCollider;
    private ResourcesMananger _resourcesMananger;
    private int _treeHP = 10;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
        _resourcesMananger = FindAnyObjectByType<ResourcesMananger>();
    }
    public void GetDamage(int damage)
    {
        _treeHP -= damage;
        if (_treeHP <= 0)
        {
            _character.LockCameraPosition = false;
            _treeCuttingPanel.SetActive(false);
            _resourcesMananger.AddWood(Random.Range(3, 6));
            _anim.SetTrigger("Cutted");
            _boxCollider.enabled = false;
            StartCoroutine(Raising());
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _miniGame.CanAttack = true;
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
    IEnumerator Raising()
    {
        yield return new WaitForSeconds(Random.Range(10, 15));
        _anim.SetTrigger("Raise");
        _treeHP = 10;
        _boxCollider.enabled = true;
    }
}
