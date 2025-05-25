using UnityEngine;
using Zenject;
public class EmployeeBuyMananger : MonoBehaviour
{
    [SerializeField] private GameObject _minerPrefab;
    [SerializeField] private GameObject _viewPort;
    private ResourcesMananger _mananger;
    private EmployeeMananger _employeeMananger;
   
    [Inject]
    private void Construct(ResourcesMananger resources, EmployeeMananger employeeMananger)
    {
        _employeeMananger = employeeMananger;
        _mananger = resources;
    }
    public void HireMiner(int cost, GameObject employeePanel)
    {
        if(cost <= _mananger.Rice && _employeeMananger.CheckMiners())
        {
            _employeeMananger.SpawnMiner();
            _mananger.AddRice(cost * -1);
        }
    }
    public void HireWoodcutter(int cost, GameObject employeePanel)
    {
        if (cost <= _mananger.Rice && _employeeMananger.CheckCutters())
        {
            _employeeMananger.SpawnWoodCutter();
            _mananger.AddRice(cost * -1);
        }
    }
    public void HireBlacksmith(int cost, GameObject employeePanel)
    {
        if (cost <= _mananger.Rice && _employeeMananger.CheckBlacksmiths())
        {
            _employeeMananger.SpawnBlacksmith();
            _mananger.AddRice(cost * -1);
        }
    }
    public void HireSamurai(int cost, GameObject employeePanel)
    {
        if (cost <= _mananger.Rice )
        {
            _mananger.AddSamurai(1);
            _mananger.AddRice(cost * -1);
        }
    }
}
