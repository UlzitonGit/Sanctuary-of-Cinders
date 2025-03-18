using System.Collections;
using UnityEngine;

public class Blacksmith : MonoBehaviour
{
    private ResourcesMananger _resources;
    [SerializeField] private int _ironCost = 50;
    [SerializeField] private int _woodCost = 50;
    [SerializeField] private int _swordCost = 100;
    [SerializeField] private int _delay = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        _resources = FindAnyObjectByType<ResourcesMananger>();
        StartCoroutine(Mining());
    }

    IEnumerator Mining()
    {
        
        if(_resources.Iron >= _ironCost && _resources.Wood >= _woodCost)
        {
            _resources.AddIron(_ironCost * -1);
            _resources.AddWood(_woodCost * -1);
            yield return new WaitForSeconds(_delay);
            _resources.AddRice(_swordCost);
            StartCoroutine(Mining());
        }
        else
        {
            yield return new WaitForSeconds(_delay);
            StartCoroutine(Mining());
        }
    }
}
