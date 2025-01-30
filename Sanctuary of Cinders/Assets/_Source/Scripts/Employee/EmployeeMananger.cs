using UnityEngine;

public class EmployeeMananger : MonoBehaviour
{
    [SerializeField] private GameObject _minerEmployee;
    [SerializeField] private Transform[] _minerSpawns;
    private int _minersCount = 0;
    private int _maxMiners = 6;
    
    public void SpawnMiner()
    {
        if (_maxMiners == _minersCount) return;
        Instantiate(_minerEmployee, _minerSpawns[_minersCount].transform.position, Quaternion.identity);
        _minersCount++;
    }
}
