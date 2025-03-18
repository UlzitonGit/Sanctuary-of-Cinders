using UnityEngine;

public class MinerUICard : EmployeeInfo
{
    public override void Hire()
    {
        _buyMananger.HireMiner(_cost, gameObject);   
    }
}
