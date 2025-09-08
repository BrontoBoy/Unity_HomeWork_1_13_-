using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Target _target;
    
    public GameObject EnemyPrefab => _enemyPrefab;
    public Vector3 Position => transform.position;
    public Target Target => _target;
    
    private void Start()
    {
        UpdateTargetColor();
    }
    
    public void UpdateTargetColor()
    {
        if (_target != null && _enemyPrefab != null)
        {
            Renderer enemyRenderer = _enemyPrefab.GetComponent<Renderer>();
            
            if (enemyRenderer != null && enemyRenderer.sharedMaterial != null)
            {
                _target.SetColor(enemyRenderer.sharedMaterial.color);
            }
        }
    }
    
    public Enemy SpawnEnemy()
    {
        GameObject enemyObject = Instantiate(_enemyPrefab, Position, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        
        if (enemy != null)
        {
            enemy.Initialize(_target.gameObject);
        }

        return enemy;
    }
}