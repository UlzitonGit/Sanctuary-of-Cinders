using System.Collections;
using UnityEngine;
using Zenject;

public class Miner : MonoBehaviour
{
    private ResourcesMananger _resources;
    [SerializeField] private int _ironToMine = 5;
    [SerializeField] private int _delay = 15;
    private UpgradeMananger _upgradeMananger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        _resources = FindAnyObjectByType<ResourcesMananger>();
        _upgradeMananger = FindAnyObjectByType<UpgradeMananger>();
        StartCoroutine(Mining());
    }

    IEnumerator Mining()
    {
        yield return new WaitForSeconds(_delay);
        _resources.AddIron(_ironToMine + _upgradeMananger.MinersMultiply);
        StartCoroutine(Mining());
    }
}
