using System.Collections;
using TMPro;
using UnityEngine;

public class Froging : MonoBehaviour
{
    [SerializeField] private ForgeZone _forgeMananger;
    [SerializeField] private RectTransform _tempArrow;
    [SerializeField] private float _fallSpeed = 10;
    [SerializeField] private RectTransform _zone;
    [SerializeField] private TextMeshProUGUI _progressText;
    [SerializeField] private GameObject _sucsessMenu;
    private float _forgeProgress = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _zone.localPosition = new Vector3(0, Random.Range(-300, 300), 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_tempArrow.localPosition.y > -400 && !Input.GetKey(KeyCode.Mouse0))
        {
            _tempArrow.localPosition = new Vector3(0, _tempArrow.localPosition.y - _fallSpeed, 0);
        }
        if (_tempArrow.localPosition.y < 410 && Input.GetKey(KeyCode.Mouse0))
        {
            _tempArrow.localPosition = new Vector3(0, _tempArrow.localPosition.y + _fallSpeed, 0);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Forge") && _forgeProgress < 100)
        {
            _forgeProgress += Time.deltaTime * 10;
            int _progress = (int)_forgeProgress;
            _progressText.text = _progress.ToString() + "%";
            if(_forgeProgress >= 100)
            {
                StartCoroutine(Sucsess());
            }
        }
    }
    IEnumerator Sucsess()
    {
        _sucsessMenu.SetActive(true);
        yield return new WaitForSeconds(2);
        _sucsessMenu.SetActive(false);
        _zone.localPosition = new Vector3(0, Random.Range(-300, 300), 0);
      
        _forgeProgress = 0;
        _progressText.text = _forgeProgress.ToString();
        _forgeMananger.CloseForging();
    }
}
