using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    //singleton
    public static EnemyPool Instance;

    [SerializeField] private GameObject GoblingPrefab;

    [SerializeField] private int poolSize = 11;

    public Queue<GameObject> enemies = new();
    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject gobling = Instantiate(GoblingPrefab);
            gobling.SetActive(false);
            enemies.Enqueue(gobling);
        }
    }

    public GameObject GetEnemy()
    {
        return enemies.Dequeue();
    }

    public void ReturnEnemy(GameObject gobling)
    {
        gobling.SetActive(false);
        enemies.Enqueue(gobling);
    }
}
