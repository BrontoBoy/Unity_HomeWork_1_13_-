using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private GameObject _enemyPrefab;
    
    public GameObject Create(Vector3 position)
    {
        if (_enemyPrefab == null)
        {
            return null;
        }
        
        GameObject newObject = Instantiate(_enemyPrefab, position, Quaternion.identity);
        
        return newObject;
    }
    
    public void SetPrefab(GameObject prefab)
    {
        _enemyPrefab = prefab;
    }
}

