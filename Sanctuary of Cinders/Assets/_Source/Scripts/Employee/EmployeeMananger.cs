using TMPro;
using UnityEngine;

public class EmployeeMananger : MonoBehaviour
{
    [SerializeField] private GameObject _minerEmployee;
    [SerializeField] private Transform[] _minerSpawns;
    [SerializeField] private TextMeshProUGUI _minersCountText;
    [SerializeField] private TextMeshProUGUI _cuttersCountText;
    [SerializeField] private TextMeshProUGUI _blacksmithCountText;
    private int _minersCount = 0;
    private int _maxMiners = 6;
    public int MinersCount => _minersCount;

    [SerializeField] private GameObject _woodcutterEmployee;
    [SerializeField] private Transform[] _woodcutterSpawns;
    private int _woodcutterCount = 0;
    private int _maxWoodcutters = 6;
    public int WoodcuttersCount => _woodcutterCount;

    [SerializeField] private GameObject _blacksmithEmployee;
    [SerializeField] private Transform[] _blacksmithSpawns;
    private int _blacksmithCount = 0;
    private int _maxblacksmith = 6;
    public int BlacksmithCount => _blacksmithCount;

    private void ShowEmployeeCountText()
    {
        _blacksmithCountText.text = _blacksmithCount.ToString() + "/" + _maxblacksmith.ToString() + " Hired";
        _minersCountText.text = _minersCount.ToString() + "/" + _maxMiners.ToString() + " Hired";
        _cuttersCountText.text = _woodcutterCount.ToString() + "/" + _maxWoodcutters.ToString() + " Hired";
    }
    public void SpawnMiner()
    {
        if (_maxMiners == _minersCount) return;
        Instantiate(_minerEmployee, _minerSpawns[_minersCount].transform.position, Quaternion.identity);
        _minersCount++;
        ShowEmployeeCountText();
    }
    public void SpawnWoodCutter()
    {
        if (_maxWoodcutters == _woodcutterCount) return;
        Instantiate(_woodcutterEmployee, _woodcutterSpawns[_woodcutterCount].transform.position, Quaternion.identity);
        _woodcutterCount++;
        ShowEmployeeCountText();
    }
    public void SpawnBlacksmith()
    {
        if (_maxblacksmith == _blacksmithCount) return;
        Instantiate(_blacksmithEmployee, _blacksmithSpawns[_blacksmithCount].transform.position, Quaternion.identity);
        _blacksmithCount++;
        ShowEmployeeCountText();
    }
    public void RestoreEmployee(int blacksmiths, int miners, int woodcutters)
    {
        for (int i = 0; i < blacksmiths; i++)
        {
            Instantiate(_blacksmithEmployee, _blacksmithSpawns[i].transform.position, Quaternion.identity);
        }
        for (int i = 0; i < miners; i++)
        {
            Instantiate(_minerEmployee, _minerSpawns[i].transform.position, Quaternion.identity);
        }
        for (int i = 0; i < woodcutters; i++)
        {
            Instantiate(_woodcutterEmployee, _woodcutterSpawns[i].transform.position, Quaternion.identity);
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
