using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private const float SpawnDelay = 2f;
    private WaitForSeconds _spawnWait;
    private bool _isSpawningActive = false;
    private Coroutine _spawningCoroutine;
    
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
        _spawningCoroutine = StartCoroutine(SpawnEnemiesRoutine());
    }
    
    public void StopSpawning()
    {
        if (_isSpawningActive == false)
        {
            return;
        }
        
        _isSpawningActive = false;
        
        if (_spawningCoroutine != null)
        {
            StopCoroutine(_spawningCoroutine);
            _spawningCoroutine = null;
        }
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
            Debug.LogWarning("Спавнер настроен неправильно!");
            return;
        }

        int randomIndex = Random.Range(0, _spawnPoints.Length);
        SpawnPoint chosenSpawnPoint = _spawnPoints[randomIndex];
        Enemy newEnemy = _enemyFactory.CreateEnemy(chosenSpawnPoint.Position);

        SpawnAction action = chosenSpawnPoint.GetComponent<SpawnAction>();
        
        if (action != null)
        {
            action.Execute(newEnemy.gameObject);
        }
    }
    
    public bool IsSpawningActive()
    {
        return _isSpawningActive;
    }
}