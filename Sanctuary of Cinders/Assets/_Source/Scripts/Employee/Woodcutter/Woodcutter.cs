using System.Collections;
using UnityEngine;
using Zenject;

public class Woodcutter : MonoBehaviour
{
    private ResourcesMananger _resources;
    [SerializeField] private int _woodToMine = 5;
    [SerializeField] private int _delay = 15;
    private UpgradeMananger _upgradeMananger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    void Start()
    {
        _resources = FindAnyObjectByType<ResourcesMananger>();
        _upgradeMananger = FindAnyObjectByType<UpgradeMananger>();
        StartCoroutine(Cutting());
    }

    IEnumerator Cutting()
    {
        yield return new WaitForSeconds(_delay);
        _resources.AddWood(_woodToMine + _upgradeMananger.WoodcuttersMultiply);
        StartCoroutine(Cutting());
    }
}
