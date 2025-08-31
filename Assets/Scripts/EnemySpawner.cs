using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private const float SpawnDelay = 2f;
    private const float GroundLevelY = 0f;
    
    private bool _isSpawningActive = false;
    private WaitForSeconds _spawnWait;

    private void OnEnable()
    {
        _spawnWait = new WaitForSeconds(SpawnDelay);
        StartSpawning();
    }

    private void OnDisable()
    {
        StopSpawning();
    }

    public void StartSpawning()
    {
        if (_isSpawningActive)
            return;

        _isSpawningActive = true;
        StartCoroutine(SpawnEnemiesRoutine());
    }

    public void StopSpawning()
    {
        _isSpawningActive = false;
    }

    private IEnumerator SpawnEnemiesRoutine()
    {
        while (_isSpawningActive)
        {
            SpawnSingleEnemy();
            yield return _spawnWait;
        }
    }

    private void SpawnSingleEnemy()
    {
        if (_spawnPoints == null || _spawnPoints.Length == 0 || _enemyFactory == null)
        {
            Debug.LogWarning("Спавнер настроен неправильно! Проверьте точки спавна и фабрику.");
            
            return;
        }
        
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        SpawnPoint chosenSpawnPoint = _spawnPoints[randomIndex];
        GameObject enemyObject = _enemyFactory.Create(chosenSpawnPoint.Position);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        
        if (enemy != null)
        {
            Vector3 randomDirection = GetRandomDirection();
            enemy.Initialize(randomDirection);
        }
    }
    
    private Vector3 GetRandomDirection()
    {
        Vector2 randomCirclePoint = Random.insideUnitCircle.normalized;
        Vector3 randomDirection = new Vector3(randomCirclePoint.x, GroundLevelY, randomCirclePoint.y);
        
        return randomDirection;
    }
}