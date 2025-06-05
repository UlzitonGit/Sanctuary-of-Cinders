using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class InGameExit : MonoBehaviour
{
    private SavesMananger _savesMananger;
    [Inject]
    private void Construct(SavesMananger saves)
    {
        _savesMananger = saves;
    }
    public void ExitToMainMenu()
    {
        _savesMananger.SaveData();
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
