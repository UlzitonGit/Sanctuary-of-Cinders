using TMPro;
using UnityEngine;

public class ResourcesMananger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _woodText;
    [SerializeField] private TextMeshProUGUI _ironText;
    [SerializeField] private TextMeshProUGUI _riceText;
    [HideInInspector] public int Wood { get; private set; }
    [HideInInspector] public int Iron { get; private set; }
    [HideInInspector] public int Rice { get; private set; }
    private void Start()
    {
        AddIron(10);
        AddWood(20);
    }
    public void AddWood(int wood)
    {
        Wood += wood;
        _woodText.text = Wood.ToString();
    }
    public void AddIron(int iron)
    {
        Iron += iron;
        _ironText.text = Iron.ToString();
    }
    public void AddRice(int rice)
    {
        Rice += rice;
        _riceText.text = Rice.ToString();
    }
}
