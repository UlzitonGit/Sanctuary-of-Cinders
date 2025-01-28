using UnityEngine;

public class SwordMoving : MonoBehaviour
{
    private Transform _sword;
    private Rigidbody _rb;
    [SerializeField] private float _speed;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _sword = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        float _dir = Input.GetAxis("Horizontal");
        _rb.linearVelocity = new Vector3(_dir, 0, 0);
        if(_sword.localPosition.x < -0.8) _sword.localPosition = new Vector3(-0.8f, 0.2f, 0);
        if(_sword.localPosition.x > 0.8) _sword.localPosition = new Vector3(0.8f, 0.2f, 0);
    }
}
