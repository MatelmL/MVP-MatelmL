using Goblin;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public void Spawn()
    {
        EnemyController enemy = EnemyPool.Instance.GetEnemy();
        enemy.transform.position = transform.position;
        enemy.transform.rotation = transform.rotation;
        enemy.gameObject.SetActive(true);
        enemy.OnSpawn();
    }
}
