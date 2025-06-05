using System.Collections;
using Cinemachine;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Zenject;

public class Mining : MiniGames
{
    [SerializeField] private GameObject _miniGamePanel;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private RectTransform _mineButton;
    [SerializeField] private GameObject _panel;
    private int _mined;
    private bool _isStarted = false;
    private int _hp = 5;
    [Inject]
    protected override void Construct(ThirdPersonController thirdPersonController, CinemachineVirtualCamera camera, ResourcesMananger manager,  TutorialMananger tutorialMananger, SoundsPlayer soundMananger)
    {
        base.Construct(thirdPersonController, camera, manager, tutorialMananger, soundMananger);
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
        if (other.CompareTag("Player") )
        {
            _panel.SetActive(true);
            if(Input.GetKey(KeyCode.E) && _isStarted == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _isStarted = true;
                _tutorialMananger.HideTutorial();
                _miniGamePanel.SetActive(true);
                _controller.SetAnim("Mining", true);
                _controller.LookAtTarget(transform.position);
                _controller.enabled = false;
                RandomizeButton();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _panel.SetActive(false);
        }
    }
    private void CloseGame()
    {
        StopAllCoroutines();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _tutorialMananger.NextTutorialPhase(3);
        _isStarted = false;
        _miniGamePanel.SetActive(false);
        _tutorialMananger.ShowTutorial();
        _controller.enabled = true;
        _controller.SetAnim("Mining", false);
        _miniGamePanel.SetActive(false);
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
        _mined += 10;
        _soundMananger.PlayMining();
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
