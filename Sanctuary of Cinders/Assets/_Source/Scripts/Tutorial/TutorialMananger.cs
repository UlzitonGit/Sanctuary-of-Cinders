using System;
using UnityEngine;

public class TutorialMananger : MonoBehaviour
{
    public bool IsEndTutorial{private set; get;}
    
    [SerializeField] private GameObject[] _tutorialPanels;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _tutorial;
    private bool _isTutorialComplited;
    private int _currentTutorialPhase;
    public void HideTutorial()
    {
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
