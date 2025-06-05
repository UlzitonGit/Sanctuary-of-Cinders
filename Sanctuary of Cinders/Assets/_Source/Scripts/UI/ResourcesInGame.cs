using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class ResourcesInGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _riceText;
    [SerializeField] private TextMeshProUGUI _ironText;
    [SerializeField] private TextMeshProUGUI _woodText;
    private ResourcesMananger _resourcesMananger;
    private float _forgeProgress = 0;
    [Inject]
    protected void Construct(ResourcesMananger resourcesMananger)
    {
        _resourcesMananger = resourcesMananger;
    }
    private void Start()
    {
        StartCoroutine(reloadText());
    }

    IEnumerator reloadText()
    {
        _ironText.text = _resourcesMananger.Iron.ToString();
        _woodText.text = _resourcesMananger.Wood.ToString();
        _riceText.text = _resourcesMananger.Rice.ToString();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(reloadText());
    }
}
