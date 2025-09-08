using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private const float SpawnDelay = 2f;
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
        {
            return;
        }

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
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        SpawnPoint chosenSpawnPoint = _spawnPoints[randomIndex];
        _enemyFactory.SetPrefab(chosenSpawnPoint.EnemyPrefab);
        GameObject enemyObject = _enemyFactory.Create(chosenSpawnPoint.Position);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        
        if (enemy != null && chosenSpawnPoint.Target != null)
        {
            enemy.Initialize(chosenSpawnPoint.Target.gameObject);
        }
    }
}