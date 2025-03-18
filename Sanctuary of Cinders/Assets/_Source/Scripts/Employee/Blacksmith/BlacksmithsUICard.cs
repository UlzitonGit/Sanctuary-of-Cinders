using UnityEngine;

public class BlacksmithsUICard : EmployeeInfo
{
    public override void Hire()
    {
        _buyMananger.HireBlacksmith(_cost, gameObject);   
    }
}
