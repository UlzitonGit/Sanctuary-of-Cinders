using System.Collections;
using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Zenject;

public class Mining : MonoBehaviour
{
    [SerializeField] private GameObject _miniGamePanel;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private RectTransform _mineButton;
    private ThirdPersonController  _characterController;
    private ResourcesMananger _mananger;
    private int _mined;
    private bool _isStarted = false;
    private int _hp = 5;
    [Inject]
    private void Construct(ThirdPersonController thirdPersonController, ResourcesMananger mananger)
    {
        _mananger = mananger;
        _characterController = thirdPersonController;     
        Debug.Log("binded");
    }
    private void Update()
    {
        if(_isStarted == true && _hp <= 0)
        {
            CloseGame();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) && _isStarted == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _isStarted = true;
            _miniGamePanel.SetActive(true);
            _characterController.enabled = false;
            RandomizeButton();
            
        }
    }
    private void CloseGame()
    {
        StopAllCoroutines();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _isStarted = false;
        _miniGamePanel.SetActive(false);
        _characterController.enabled = true;
        _mananger.AddIron(_mined);
        _mined = 0;
        _hp = 5;

    }
    private void RandomizeButton()
    {
        _mineButton.transform.localPosition = new Vector2(Random.Range(-650, 650), Random.Range(-300, 300));
        StartCoroutine(Delaying());
    }
    public void ButtonClicked()
    {
        _mined += 5;
        StopAllCoroutines();
        RandomizeButton();
        _scoreText.text = "+" + _mined.ToString();
        
        _hp -= 1;
    }
    IEnumerator Delaying()
    {
        yield return new WaitForSeconds(1.3f);
        _hp -= 1;
        RandomizeButton();
    }
}
