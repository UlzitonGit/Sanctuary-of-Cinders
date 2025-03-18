using UnityEngine;

public class BlacksmithsUICard : EmployeeInfo
{
    public override void Hire()
    {
        _buyMananger.HireMiner(_cost, gameObject);   
    }
}
