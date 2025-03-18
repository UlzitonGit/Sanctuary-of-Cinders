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
            employeePanel.SetActive(false);
            _employeeMananger.SpawnMiner();
            _mananger.AddRice(cost * -1);
        }
    }
}
