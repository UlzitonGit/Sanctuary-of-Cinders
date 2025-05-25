using UnityEngine;
[System.Serializable]
public class ResourcesData
{
    public int Rice{private set; get;}
    public int Iron{private set; get;}
    public int Wood{private set; get;}
    public int Samurai{private set; get;}
    public int CostMultyply{private set; get;}
    public int Miners{private set; get;}
    public int BlackSmiths{private set; get;}
    public int Woodcutters{private set; get;}
    public ResourcesData(ResourcesMananger resources, EmployeeMananger employee)
    {
        Rice = resources.Rice;
        Iron = resources.Iron;
        Wood = resources.Wood;
        CostMultyply = resources.CostMultiply;
        Samurai = resources.Samurai;
        Miners = employee.MinersCount;
        Woodcutters = employee.WoodcuttersCount;
        BlackSmiths = employee.BlacksmithCount;
    } 
}
