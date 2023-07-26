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
        enemy.transform.GetChild(1).localScale = Vector3.one;
        for (int i = 0; i < enemy.transform.childCount; i++)
        {
            enemy.transform.GetChild(i).localPosition = Vector3.zero;
        }
        enemy.SetActive(true);
        enemy.GetComponent<EnemyState>().StartMoving();
        enemy.GetComponent<EnemyMovement>().Initialize();
    }
}
