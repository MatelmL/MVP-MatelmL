using Goblin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public void Spawn()
    {
        GameObject enemy = EnemyPool.Instance.GetEnemy();
        enemy.transform.position = transform.position;
        enemy.transform.rotation = transform.rotation;
        enemy.SetActive(true);
        enemy.GetComponent<EnemyState>().StartMoving();
        enemy.GetComponent<EnemyMovement>().Initialize();
    }
}
