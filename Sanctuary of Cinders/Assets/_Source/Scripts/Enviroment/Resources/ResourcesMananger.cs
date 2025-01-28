using TMPro;
using UnityEngine;

public class ResourcesMananger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _woodText;
    private int _wood = 0;  

    public void AddWood(int wood)
    {
        _wood += wood;
        _woodText.text = _wood.ToString();
    }
}
