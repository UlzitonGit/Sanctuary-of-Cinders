using System;
using UnityEngine;
using Zenject;
public class TutorialMananger : MonoBehaviour
{
    public bool IsEndTutorial{private set; get;}
    
    [SerializeField] private GameObject[] _tutorialPanels;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _tutorial;
    private ResourcesMananger _resourcesMananger;
    private bool _isTutorialComplited;
    private int _currentTutorialPhase;
    [Inject]
    private void Construct(ResourcesMananger resources)
    {
        _resourcesMananger = resources;
    }
    public void HideTutorial()
    {
        Debug.LogWarning("HideTutorial");
        _tutorial.SetActive(false);
    }

    public void ShowTutorial()
    {
        if (_isTutorialComplited) return;
        _tutorial.SetActive(true);
    }

    private void Update()
    {
        if (_isTutorialComplited) return;
    }

    public void NextTutorialPhase(int phase)
    {
        if (_isTutorialComplited || phase == _tutorialPanels.Length)
        {
            _isTutorialComplited = true;
            IsEndTutorial = true;
            _tutorial.SetActive(false);
            return;
        }
        if (phase < _currentTutorialPhase) return;
        if(phase == 4 && _currentTutorialPhase != 4) _resourcesMananger.AddRice(2000); 
        _currentTutorialPhase = phase;
        _tutorialPanels[phase - 1].SetActive(false);
        _tutorialPanels[phase].SetActive(true);
    }

    public void EndTutorial(bool isEndTutorial)
    {
        _isTutorialComplited = isEndTutorial;
        if(_isTutorialComplited)HideTutorial();
    }
}
