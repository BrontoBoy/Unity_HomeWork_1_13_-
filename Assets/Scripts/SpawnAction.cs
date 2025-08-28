using UnityEngine;

public abstract class SpawnAction : MonoBehaviour
{
    public abstract void Execute(GameObject spawnedObject);
}