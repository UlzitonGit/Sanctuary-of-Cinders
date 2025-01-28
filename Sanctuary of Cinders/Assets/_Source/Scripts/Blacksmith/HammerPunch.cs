using System.Collections;
using UnityEngine;

public class HammerPunch : MonoBehaviour
{
    [SerializeField] private Animator _hammerAnimation;
    public bool canAttack = true;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && canAttack)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        canAttack = false ;
        _hammerAnimation.SetTrigger("Punch");
        yield return new WaitForSeconds(1.2f);
        canAttack = true ;
    }
}
