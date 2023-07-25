using Goblin;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public void Spawn()
    {
        GameObject enemy = EnemyPool.Instance.GetEnemy();
        enemy.transform.position = transform.position;
        enemy.transform.rotation = transform.rotation;
        
        // Todo: move all this to an enemy controller
        enemy.SetActive(true);
        enemy.GetComponent<EnemyState>().StartMoving();
        enemy.GetComponent<EnemyMovement>().Initialize();
    }
}
