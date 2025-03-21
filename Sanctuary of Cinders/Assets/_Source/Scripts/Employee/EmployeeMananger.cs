using UnityEngine;

public class EmployeeMananger : MonoBehaviour
{
    [SerializeField] private GameObject _minerEmployee;
    [SerializeField] private Transform[] _minerSpawns;
    private int _minersCount = 0;
    private int _maxMiners = 3;
    public int MinersCount => _minersCount;

    [SerializeField] private GameObject _woodcutterEmployee;
    [SerializeField] private Transform[] _woodcutterSpawns;
    private int _woodcutterCount = 0;
    private int _maxWoodcutters = 3;
    public int WoodcuttersCount => _woodcutterCount;

    [SerializeField] private GameObject _blacksmithEmployee;
    [SerializeField] private Transform[] _blacksmithSpawns;
    private int _blacksmithCount = 0;
    private int _maxblacksmith = 3;
    public int BlacksmithCount => _blacksmithCount;

    public void SpawnMiner()
    {
        if (_maxMiners == _minersCount) return;
        Instantiate(_minerEmployee, _minerSpawns[_minersCount].transform.position, Quaternion.identity);
        _minersCount++;
    }
    public void SpawnWoodCutter()
    {
        if (_maxWoodcutters == _woodcutterCount) return;
        Instantiate(_woodcutterEmployee, _woodcutterSpawns[_woodcutterCount].transform.position, Quaternion.identity);
        _woodcutterCount++;
    }
    public void SpawnBlacksmith()
    {
        if (_maxblacksmith == _blacksmithCount) return;
        Instantiate(_blacksmithEmployee, _blacksmithSpawns[_blacksmithCount].transform.position, Quaternion.identity);
        _blacksmithCount++;
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
    }
}
