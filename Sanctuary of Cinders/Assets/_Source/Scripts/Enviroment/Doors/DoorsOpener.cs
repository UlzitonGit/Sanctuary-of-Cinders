using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class DoorsOpener : MonoBehaviour
{
    [SerializeField] private Animator _doorAnim;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _doorAnim.SetBool("Open", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _doorAnim.SetBool("Open", false);
        }
    }
}
