using System.Collections;
using UnityEngine;

public class Woodcutter : MonoBehaviour
{
    private ResourcesMananger _resources;
    [SerializeField] private int _woodToMine = 5;
    [SerializeField] private int _delay = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        _resources = FindAnyObjectByType<ResourcesMananger>();
        StartCoroutine(Cutting());
    }

    IEnumerator Cutting()
    {
        yield return new WaitForSeconds(_delay);
        _resources.AddWood(_woodToMine);
        StartCoroutine(Cutting());
    }
}
