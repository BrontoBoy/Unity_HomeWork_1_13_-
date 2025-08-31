using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToCreate;
    
    public GameObject Create(Vector3 position)
    {
        GameObject newObject = Instantiate(_prefabToCreate, position, Quaternion.identity);
        
        return newObject;
    }
}

