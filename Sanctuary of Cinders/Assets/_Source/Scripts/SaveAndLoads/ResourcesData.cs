using UnityEngine;
[System.Serializable]
public class ResourcesData
{
    public int Rice;
    public int Iron;
    public int Wood;

    public int Miners;
    public int BlackSmiths;
    public int Woodcutters;
    public ResourcesData(ResourcesMananger resources, EmployeeMananger employee)
    {
        Rice = resources.Rice;
        Iron = resources.Iron;
        Wood = resources.Wood;

        Miners = employee.MinersCount;
        Woodcutters = employee.WoodcuttersCount;
        BlackSmiths = employee.BlacksmithCount;
    } 
}
