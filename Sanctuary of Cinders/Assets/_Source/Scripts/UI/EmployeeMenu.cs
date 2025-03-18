using UnityEngine;
using UnityEngine.UI;

public class EmployeeMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _employeePanels;
    [SerializeField] private Button[] _panelButtons;
    public void ChangeEmployeePanel(GameObject panel)
    {
        foreach (var item in _employeePanels)
        {
            if (item == panel) item.SetActive(true);
            else item.SetActive(false);
        }
    }
}
