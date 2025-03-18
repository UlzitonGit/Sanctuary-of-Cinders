using UnityEngine;

public class WoodcutterUICard : EmployeeInfo
{
    public override void Hire()
    {
        _buyMananger.HireMiner(_cost, gameObject);   
    }
}
