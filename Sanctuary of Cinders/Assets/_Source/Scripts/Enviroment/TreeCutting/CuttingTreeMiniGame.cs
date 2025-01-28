using System.Collections;
using UnityEngine;

public class CuttingTreeMiniGame : MonoBehaviour
{
    [SerializeField] RectTransform zone; 

    public TreeZone CurrentTree;
    public int Damage;

    public bool CanAttack = true;
    private void Start()
    {
        CanAttack = true;
        zone.localPosition = new Vector3(0, Random.Range(-300, 300), 0);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Cut"))
        {
            print("zone");
            if (Input.GetKey(KeyCode.Mouse0) && CanAttack)
            {
                
                StartCoroutine(AttackReload());
                print("Cut!");
                CurrentTree.GetDamage(Damage);
                zone.localPosition = new Vector3(0, Random.Range(-300, 300), 0);
            }
           
        }
    }
    IEnumerator AttackReload()
    {
        CanAttack = false;
        yield return new WaitForSeconds(0.6f);
        CanAttack = true;
    }
}
