using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    private bool _opened = false;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && !_opened)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            _menu.SetActive(true);
            _opened = true;
        }
        else if (Input.GetKeyDown("escape") && _opened)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            _menu.SetActive(false);
            _opened = false;
        }
    }
}
