using UnityEngine;

public class WoodcutterUICard : EmployeeInfo
{
    public override void Hire()
    {
        _buyMananger.HireWoodcutter(_cost, gameObject);   
    }
}
