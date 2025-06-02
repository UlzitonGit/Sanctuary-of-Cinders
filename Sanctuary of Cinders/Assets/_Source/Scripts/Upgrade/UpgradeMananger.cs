using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradeMananger : MonoBehaviour
{
    [SerializeField] private int _basicCost = 2000;
    public int WoodcuttersMultiply { get; private set; } = 1;
    public float BlackSmithsMultiply { get; private set; } = 1;
    public int MinersMultiply { get; private set; } = 1;
    public int WoodUps { get; private set; } = 1;
    public int BlackUps { get; private set; } = 1;
    public int MinersUps { get; private set; } = 1;
    private ResourcesMananger _resources;
    [SerializeField] private TextMeshProUGUI _woodcuttersText;
    [SerializeField] private TextMeshProUGUI _blackSmithsText;
    [SerializeField] private TextMeshProUGUI _minersText;
    [SerializeField] private Image _minersBar;
    [SerializeField] private Image _woodBar;
    [SerializeField] private Image _blackBar;
    private void Start()
    {
        if(WoodUps == 0) WoodUps = 1;
        if(BlackUps == 0) BlackUps = 1;
        if (MinersUps == 0) MinersUps = 1;
    }

 

    [Inject]
    private void Construct(ResourcesMananger resources)
    {
        _resources = resources;
    }
    public void AddMinersMultiply(int mult)
    {
        if((MinersUps * _basicCost <= _resources.Rice) && MinersUps <= 4)
        {
            print("Upgrade");
            MinersMultiply += mult;
            MinersUps++;
            _resources.AddRice(MinersUps * _basicCost);
            UpdateUI();

        }
    }
    public void AddBlacksmithsMultiply(float mult)
    {
        if ((BlackUps * _basicCost <= _resources.Rice) && BlackUps <= 4)
        {
            print("Upgrade");
            BlackSmithsMultiply -= mult;
            BlackUps++;
            _resources.AddRice(BlackUps * _basicCost);
            UpdateUI();
        }
    }
    public void AddWoodcutters(int mult)
    {
        if ((WoodUps * _basicCost <= _resources.Rice) && WoodUps <= 4)
        {
            print("Upgrade");
            WoodcuttersMultiply += mult;
            WoodUps++;
            _resources.AddRice(WoodUps * _basicCost);
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        if (MinersUps <= 4) _minersText.text = (MinersUps * _basicCost).ToString();
        else _minersText.text = "max";
        if (BlackUps <= 4) _blackSmithsText.text = (BlackUps * _basicCost).ToString();
        else _blackSmithsText.text = "max";
        if (WoodUps <= 4) _woodcuttersText.text = (WoodUps * _basicCost).ToString();
        else _woodcuttersText.text = "max";
        _minersBar.fillAmount = MinersUps * 0.2f;
        _woodBar.fillAmount = WoodUps * 0.2f;
        _blackBar.fillAmount = BlackUps * 0.2f;
    }
    public void RestoreMultiply(int multWood, int multMiners, float multBlack, int woodUps, int blackUps, int minerUps)
    {
        WoodcuttersMultiply = multWood;
        BlackSmithsMultiply = multBlack;
        MinersMultiply = multMiners;
        WoodUps = woodUps;
        BlackUps = blackUps;
        MinersUps = minerUps;

        if (WoodUps == 0) WoodUps = 1;
        if (BlackUps == 0) BlackUps = 1;
        if (MinersUps == 0) MinersUps = 1;
        UpdateUI();
    }
}
