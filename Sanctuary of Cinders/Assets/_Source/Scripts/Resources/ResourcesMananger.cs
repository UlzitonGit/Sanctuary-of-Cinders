using System.Collections;
using TMPro;
using UnityEngine;

public class ResourcesMananger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _woodText;
    [SerializeField] private TextMeshProUGUI _ironText;
    [SerializeField] private TextMeshProUGUI _riceText;
    [SerializeField] private TextMeshProUGUI _samuraiText;
    [SerializeField] private GameObject[] _fightZones;
    
    private int _wood;
    private int _iron;
    private int _rice;
    private int _samurais;
    private int _costMultiply = 1;
    
    public int CostMultiply => _costMultiply;
    public int Rice => _rice;
    public int Wood => _wood;
    public int Iron => _iron;
    public int Samurai => _samurais;
    private void Start()
    {
        ShowResources();
        AddRice(300);
    }
    private void ShowResources()
    {
        _woodText.text = _wood.ToString();
        _ironText.text = _iron.ToString();
        _riceText.text = _rice.ToString();
        _samuraiText.text = _samurais.ToString() + " Нанято";
    }
    
    public void AddWood(int wood)
    {
        _wood += wood;
        _woodText.text = _wood.ToString();
    }
    public void AddIron(int iron)
    {
        _iron += iron;
        _ironText.text = _iron.ToString();
    }
    public void AddRice(int rice)
    {
        if(_costMultiply == 0) _costMultiply = 1;
        print(_costMultiply);
        if(rice > 0)   _rice += rice * _costMultiply;
        else _rice += rice;
        _riceText.text = _rice.ToString();
    }

    public void AddSamurai(int samurai)
    {
        _samurais += samurai;
        _samuraiText.text = _samurais.ToString() + " Нанято";
    }

    public void AddCostMultiply(int costMultiply)
    {
        _costMultiply = costMultiply;
        for (int i = 0; i < _fightZones.Length; i++)
        {
            if (i + 1 < costMultiply)
            {
                _fightZones[i].SetActive(false);
            }
        }
    }
}
