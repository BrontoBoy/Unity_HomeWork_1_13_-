using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    private const float SpawnDelay = 2f;
    
    [SerializeField] private SpawnPoint[] _spawnPoints;
    
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
        Enemy enemy = chosenSpawnPoint.SpawnEnemy();
    }
}