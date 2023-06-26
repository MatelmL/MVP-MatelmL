using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SpawnManager : MonoBehaviour
{
    public int sizeWave;
    [NonSerialized] public int enemiesActive = 0;
     public bool isActive = true;
    Spawner[] spawners;
    public static SpawnManager instance;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this.gameObject);
        else instance = this;
    }

    void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
        // esto esta en el start pero yo lo pondria en un evento llamado StartGame
        SpawnWave();
    }

    public void ChangeState() =>isActive = false;


    public void SpawnWave()
    {
        if (enemiesActive <= 0 && isActive)
        {
            List<Spawner> spawnersActive = spawners.ToList();
            enemiesActive = sizeWave;
            for (int i = 0; i < sizeWave; i++)
            {
                int randomSpawn = UnityEngine.Random.Range(0, spawnersActive.Count);
                spawnersActive[randomSpawn].SpawnEnemy();
                spawnersActive.Remove(spawnersActive[randomSpawn]);
            }
        }
    }
}
