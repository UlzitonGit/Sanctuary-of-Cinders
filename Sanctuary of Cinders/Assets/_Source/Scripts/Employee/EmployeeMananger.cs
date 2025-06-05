using TMPro;
using UnityEngine;
using Zenject;

public class EmployeeMananger : MonoBehaviour
{
    [SerializeField] private GameObject _minerEmployee;
    [SerializeField] private GameObject[] _minerSpawns;
    [SerializeField] private TextMeshProUGUI _minersCountText;
    [SerializeField] private TextMeshProUGUI _cuttersCountText;
    [SerializeField] private TextMeshProUGUI _blacksmithCountText;
    private int _minersCount = 0;
    private int _maxMiners = 6;
    public int MinersCount => _minersCount;

    [SerializeField] private GameObject _woodcutterEmployee;
    [SerializeField] private GameObject[] _woodcutterSpawns;
    private int _woodcutterCount = 0;
    private int _maxWoodcutters = 6;
    public int WoodcuttersCount => _woodcutterCount;

    [SerializeField] private GameObject _blacksmithEmployee;
    [SerializeField] private GameObject[] _blacksmithSpawns;
    private int _blacksmithCount = 0;
    private int _maxblacksmith = 6;
    public int BlacksmithCount => _blacksmithCount;
    private TutorialMananger _tutorialMananger;

    [Inject]
    protected void Construct(TutorialMananger tutorialMananger)
    {
        _tutorialMananger = tutorialMananger;
    }
    private void ShowEmployeeCountText()
    {
        _blacksmithCountText.text = _blacksmithCount.ToString() + "/" + _maxblacksmith.ToString() + " Нанято";
        _minersCountText.text = _minersCount.ToString() + "/" + _maxMiners.ToString() + " Нанято";
        _cuttersCountText.text = _woodcutterCount.ToString() + "/" + _maxWoodcutters.ToString() + " Нанято";
    }
    public void SpawnMiner()
    {
        if (_maxMiners == _minersCount) return;
        _minerSpawns[_minersCount].SetActive(true);
        _minersCount++;
        _tutorialMananger.HideTutorial();
        _tutorialMananger.NextTutorialPhase(5);
        ShowEmployeeCountText();
     
    }
    public void SpawnWoodCutter()
    {
        if (_maxWoodcutters == _woodcutterCount) return;
        _woodcutterSpawns[_woodcutterCount].SetActive(true);
        _tutorialMananger.NextTutorialPhase(5);
        _woodcutterCount++;
        ShowEmployeeCountText();
     
    }
    public void SpawnBlacksmith()
    {
        if (_maxblacksmith == _blacksmithCount) return;
        _blacksmithSpawns[_blacksmithCount].SetActive(true);
        _tutorialMananger.NextTutorialPhase(5);
        _blacksmithCount++;
        ShowEmployeeCountText();
    }
    public void RestoreEmployee(int blacksmiths, int miners, int woodcutters)
    {
        for (int i = 0; i < blacksmiths; i++)
        {
            _blacksmithSpawns[i].SetActive(true);
        }
        for (int i = 0; i < miners; i++)
        {
            _minerSpawns[i].SetActive(true);
        }
        for (int i = 0; i < woodcutters; i++)
        {
            _woodcutterSpawns[i].SetActive(true);
        }
        _woodcutterCount = woodcutters;
        _minersCount = miners;
        _blacksmithCount = blacksmiths;
        ShowEmployeeCountText();
  
    }

    public bool CheckMiners()
    {
        return _minersCount < _maxMiners;
    }
    public bool CheckCutters()
    {
        return _woodcutterCount < _maxWoodcutters;
    }
    public bool CheckBlacksmiths()
    {
        return _blacksmithCount < _maxblacksmith;
    }
}
