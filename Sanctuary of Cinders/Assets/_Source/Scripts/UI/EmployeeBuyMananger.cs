using UnityEngine;

public class EmployeeBuyMananger : MonoBehaviour
{
    [SerializeField] private GameObject _minerPrefab;
    [SerializeField] private GameObject _viewPort;
    [SerializeField] private ResourcesMananger _mananger;
    [SerializeField] private EmployeeMananger _employeeMananger;
   

    public void Hire(int cost)
    {
        if(cost <= _mananger.Rice)
        {
            _employeeMananger.SpawnMiner();
            _mananger.AddRice(cost * -1);
        }
    }
}
