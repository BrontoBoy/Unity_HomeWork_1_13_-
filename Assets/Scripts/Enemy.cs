using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private Target _target;
    
    private void Update()
    {
        MoveTowardsTarget();
    }
    
    public void Initialize(Target target)
    {
        _target = target;
    }
    
    private void MoveTowardsTarget()
    {
        if (_target == null)
        {
            return;
        }
        
        Vector3 targetPosition = _target.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _speed);
        transform.LookAt(_target.transform);
    }
}