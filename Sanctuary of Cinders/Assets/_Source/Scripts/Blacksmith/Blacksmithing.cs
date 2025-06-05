using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class Blacksmithing : MonoBehaviour
{
    [SerializeField] private BlacksmithZone _forgeMananger;
    [SerializeField] private GameObject _sucsessMenu;
    private SoundsPlayer _soundMananger;
    private float _forgeProgress = 0;
    private int _hitsToMake = 5;
    [Inject]
    protected void Construct(SoundsPlayer soundMananger)
    {
        _soundMananger = soundMananger;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localPosition = new Vector3(Random.Range(-0.4f, 0.4f), -3, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blacksmith"))
        {
            _hitsToMake--;
            _soundMananger.PlayBlack();
            transform.localPosition = new Vector3(Random.Range(-0.4f, 0.4f), -3, 0);
            if (_hitsToMake <= 0)
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
        _soundMananger.PlayReady();

        _forgeProgress = 0;
       
        _forgeMananger.OpenSellMenu();
        _hitsToMake = 5;
    }
}
