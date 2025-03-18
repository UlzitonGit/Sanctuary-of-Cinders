using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Zenject;

public abstract class EmployeeInfo : MonoBehaviour
{
    [SerializeField] protected int _cost = 300;
    [SerializeField] protected string _role;
    [SerializeField] protected TextMeshProUGUI _costText;
    [SerializeField] protected TextMeshProUGUI _name;
    [SerializeField] protected TextMeshProUGUI _work;
    protected EmployeeBuyMananger _buyMananger;
    [Inject]
    virtual protected void Construct(EmployeeBuyMananger manager)
    {
        _buyMananger = manager;
        Debug.Log("binded");
    }
    void Start()
    {
        _costText.text = _cost.ToString();
        _work.text = _role;
    }
    public abstract void Hire();
}
