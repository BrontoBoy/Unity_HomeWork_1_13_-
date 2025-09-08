using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _reachThreshold = 0.1f;
    
    private Renderer _renderer;
    private int _currentWaypointIndex = 0;
    
    private void Awake()
    {
        FindFlagRenderer();
    }
    
    private void Update()
    {
        if (_waypoints != null && _waypoints.Length > 0)
        {
            MoveToWaypoint();
        }
    }
    
    private void FindFlagRenderer()
    {
        Transform flagTransform = transform.Find("Flag");
        _renderer = flagTransform.GetComponent<Renderer>();
    }

    public void SetColor(Color enemyColor)
    { 
        if (_renderer != null)
        {
            _renderer.material.color = enemyColor;
        }
    }
    
    private void MoveToWaypoint()
    {
        Transform currentWaypoint = _waypoints[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, currentWaypoint.position);
        
        if (distance <= _reachThreshold)
        {
            _currentWaypointIndex++;
            
            if (_currentWaypointIndex >= _waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
        }
    }
}

