using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMananger : MonoBehaviour
{
    private string _pathDest = "data.txt";
    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayNewGame()
    {
        SaveSystem.Delete();
        SceneManager.LoadScene(2);
    } 
}
