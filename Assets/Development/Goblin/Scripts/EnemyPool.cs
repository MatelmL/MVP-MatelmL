using System.Collections;
using System.Collections.Generic;
using Goblin;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    //singleton
    public static EnemyPool Instance;

    [SerializeField] private GameObject GoblingPrefab;

    [SerializeField] private int poolSize = 11;

    public Queue<EnemyController> enemies = new();
    public List<EnemyController> enemiesList = new();
    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject gobling = Instantiate(GoblingPrefab, transform);
            EnemyController enemyController = gobling.GetComponent<EnemyController>();
            gobling.SetActive(false);
            enemies.Enqueue(enemyController);
            enemiesList.Add(enemyController);
        }
    }

    public EnemyController GetEnemy()
    {
        return enemies.Dequeue();
    }

    public void ReturnEnemy(EnemyController gobling)
    {
        gobling.gameObject.SetActive(false);
        enemies.Enqueue(gobling);
    }
}
