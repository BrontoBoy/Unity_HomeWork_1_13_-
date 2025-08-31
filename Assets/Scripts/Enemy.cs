using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private Rigidbody _rigidbody;
    private Vector3 _movementDirection;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void Initialize(Vector3 direction)
    {
        _movementDirection = direction.normalized;
        transform.rotation = Quaternion.LookRotation(_movementDirection);
    }
    
    private void FixedUpdate()
    {
        if (_movementDirection != Vector3.zero)
        {
            _rigidbody.linearVelocity = _movementDirection * _speed;
        }
    }
}
