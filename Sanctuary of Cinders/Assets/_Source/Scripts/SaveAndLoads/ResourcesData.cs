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
    public int WoodcuttersMultiply { get; private set; }
    public float BlackSmithsMultiply { get; private set; }
    public int MinersMultiply { get; private set; }
    public int WoodUps { get; private set; }
    public int BlackUps { get; private set; }
    public int MinersUps { get; private set; }
    public ResourcesData(ResourcesMananger resources, EmployeeMananger employee, UpgradeMananger upgradeMananger)
    {
        Rice = resources.Rice;
        Iron = resources.Iron;
        Wood = resources.Wood;
        CostMultyply = resources.CostMultiply;
        Samurai = resources.Samurai;
        Miners = employee.MinersCount;
        Woodcutters = employee.WoodcuttersCount;
        BlackSmiths = employee.BlacksmithCount;
        WoodcuttersMultiply = upgradeMananger.WoodcuttersMultiply;
        BlackSmithsMultiply = upgradeMananger.BlackSmithsMultiply;
        MinersMultiply = upgradeMananger.MinersMultiply;
        WoodUps = upgradeMananger.WoodUps;
        BlackUps = upgradeMananger.BlackUps;
        MinersUps = upgradeMananger.MinersUps;
    } 
}
