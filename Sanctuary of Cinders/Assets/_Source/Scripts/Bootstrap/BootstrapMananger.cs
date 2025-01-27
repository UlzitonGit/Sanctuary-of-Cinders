using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BootstrapMananger : MonoBehaviour
{
    [SerializeField] private Image progressBar;
 
    void Start()
    {
        //initialize
    }

    
    void Update()
    {
        progressBar.fillAmount += Time.deltaTime / 3;
        if (progressBar.fillAmount == 1) SceneManager.LoadScene(1);
    }
}
