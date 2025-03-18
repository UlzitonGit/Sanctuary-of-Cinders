using UnityEngine;

public class EmployeeMananger : MonoBehaviour
{
    [SerializeField] private GameObject _minerEmployee;
    [SerializeField] private Transform[] _minerSpawns;
    private int _minersCount = 0;
    private int _maxMiners = 3;

    [SerializeField] private GameObject _woodcutterEmployee;
    [SerializeField] private Transform[] _woodcutterSpawns;
    private int _woodcutterCount = 0;
    private int _maxWoodcutters = 3;

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
}
