using System.Collections;
using UnityEngine;
using Zenject;

public class SavesMananger : MonoBehaviour
{
    private EmployeeMananger _employee;
    private ResourcesMananger _resources;
    private float _saveDuration = 10;
    [Inject]
    private void Construct(ResourcesMananger resources, EmployeeMananger employee)
    {
        _employee = employee;
        _resources = resources;
    }
    private void Start()
    {
        LoadData();
        StartCoroutine(SaveCycle());
    }
    private void SaveData()
    {
        SaveSystem.SaveData(_resources, _employee);
    }
    private void LoadData()
    {
        ResourcesData data = SaveSystem.LoadResoures();
        _resources.AddIron(data.Iron);
        _resources.AddWood(data.Wood);
        _resources.AddRice(data.Rice);
        _resources.AddSamurai(data.Samurai);
        _resources.AddCostMultiply(data.CostMultyply);
        _employee.RestoreEmployee(data.BlackSmiths, data.Miners, data.Woodcutters);
    }
    IEnumerator SaveCycle()
    {
        yield return new WaitForSeconds(_saveDuration);
        SaveData();
        StartCoroutine(SaveCycle());
    }
}
