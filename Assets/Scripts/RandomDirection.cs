using UnityEngine;

public class RandomDirection : SpawnAction
{
    public override void Execute(GameObject spawnedObject)
    {

        if (spawnedObject == null)
        {
            return;
        }
        
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        
        Vector3 direction = new Vector3(randomDirection.x, 0f, randomDirection.y);
        
        spawnedObject.transform.rotation = Quaternion.LookRotation(direction);
    }
}