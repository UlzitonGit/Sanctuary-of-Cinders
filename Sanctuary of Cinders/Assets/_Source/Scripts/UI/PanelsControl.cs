using UnityEngine;

public class PanelsControl : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;

    public void ChoosePanel(GameObject panel)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (panels[i] != panel)
            {
                panels[i].SetActive(false);
            }
            else
            {
                panels[i].SetActive(true);
            }
        }
    }
}
