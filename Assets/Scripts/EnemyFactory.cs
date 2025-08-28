using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    
    public Enemy CreateEnemy(Vector3 position)
    {
        Enemy newEnemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
        return newEnemy;
    }
}

