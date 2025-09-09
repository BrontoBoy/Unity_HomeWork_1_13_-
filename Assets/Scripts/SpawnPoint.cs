using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target _target;
    
    public Enemy EnemyPrefab => _enemyPrefab;
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
            if (_enemyPrefab.TryGetComponent(out Renderer enemyRenderer) && enemyRenderer.sharedMaterial != null)
            {
                _target.SetColor(enemyRenderer.sharedMaterial.color);
            }
        }
    }
    
    public Enemy SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, Position, Quaternion.identity);
        enemy.Initialize(_target);

        return enemy;
    }
}