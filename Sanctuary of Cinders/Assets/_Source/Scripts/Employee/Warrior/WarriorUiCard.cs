using UnityEngine;

public class WarriorUiCard : EmployeeInfo
{
    public override void Hire()
    {
        _buyMananger.HireBlacksmith(_cost, gameObject);   
    }
}
