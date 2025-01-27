using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMananger : MonoBehaviour
{
   
    public void Play()
    {
        SceneManager.LoadScene(2);
    }
}
