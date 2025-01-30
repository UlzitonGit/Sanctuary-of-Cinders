using System.Collections;
using UnityEngine;

public class Miner : MonoBehaviour
{
    private ResourcesMananger _resources;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        _resources = FindAnyObjectByType<ResourcesMananger>();
        StartCoroutine(Mining());
    }

    IEnumerator Mining()
    {
        yield return new WaitForSeconds(6);
        _resources.AddIron(15);
        StartCoroutine(Mining());
    }
}
