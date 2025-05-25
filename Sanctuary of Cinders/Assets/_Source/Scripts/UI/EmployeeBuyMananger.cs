using UnityEngine;

public class EmployeeBuyMananger : MonoBehaviour
{
    [SerializeField] private GameObject _minerPrefab;
    [SerializeField] private GameObject _viewPort;
    [SerializeField] private ResourcesMananger _mananger;
    [SerializeField] private EmployeeMananger _employeeMananger;
   
    
    public void HireMiner(int cost, GameObject employeePanel)
    {
        if(cost <= _mananger.Rice)
        {
            _employeeMananger.SpawnMiner();
            _mananger.AddRice(cost * -1);
        }
    }
    public void HireWoodcutter(int cost, GameObject employeePanel)
    {
        if (cost <= _mananger.Rice)
        {
            _employeeMananger.SpawnWoodCutter();
            _mananger.AddRice(cost * -1);
        }
    }
    public void HireBlacksmith(int cost, GameObject employeePanel)
    {
        if (cost <= _mananger.Rice)
        {
            _employeeMananger.SpawnBlacksmith();
            _mananger.AddRice(cost * -1);
        }
    }
    public void HireSamurai(int cost, GameObject employeePanel)
    {
        if (cost <= _mananger.Rice)
        {
            _mananger.AddSamurai(1);
            _mananger.AddRice(cost * -1);
        }
    }
}
