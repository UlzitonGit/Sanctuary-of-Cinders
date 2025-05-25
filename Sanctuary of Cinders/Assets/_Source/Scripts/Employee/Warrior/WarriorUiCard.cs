using UnityEngine;

public class WarriorUiCard : EmployeeInfo
{
    public override void Hire()
    {
        _buyMananger.HireSamurai(_cost, gameObject);   
    }
}
