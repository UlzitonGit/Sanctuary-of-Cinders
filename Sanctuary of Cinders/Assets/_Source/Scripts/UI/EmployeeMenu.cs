using UnityEngine;
using UnityEngine.UI;

public class EmployeeMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _employeePanels;
    [SerializeField] private Button[] _panelButtons;
    public void ChangeEmployeePanel(GameObject panel, Button button)
    {
        foreach (var item in _employeePanels)
        {
            if (item == panel) item.SetActive(true);
            else item.SetActive(false);
        }
        foreach (var item in _panelButtons)
        {
            if (item == button) button.interactable = false;
            else button.interactable = true;
        }
    }
}
