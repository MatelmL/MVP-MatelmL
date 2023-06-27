using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SpawnManager : MonoBehaviour
{
    [NonSerialized] public int enemiesActive = 0;
     public bool isActive = true;
    Spawner[] spawners;
    public static SpawnManager instance;
    [SerializeField] Level[] levels;
    public int actualLevel = -1;
    int enemiesToSpawn, wavesToSpawn, minSizeWave,maxSizeWave;
    float timeToSpawn;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this.gameObject);
        else instance = this;
    }

    void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
        // esto esta en el start pero yo lo pondria en un evento llamado StartGame
        StartLevel();
    }

    public void ChangeState() =>isActive = false;


    public void SpawnWave(int sizeWave)
    {
            List<Spawner> spawnersActive = spawners.ToList();
            enemiesActive = sizeWave;
            for (int i = 0; i < sizeWave; i++)
            {
                int randomSpawn = UnityEngine.Random.Range(0, spawnersActive.Count);
                spawnersActive[randomSpawn].SpawnEnemy();
                spawnersActive.Remove(spawnersActive[randomSpawn]);
            }
        enemiesToSpawn -= sizeWave;
    }

    IEnumerator LevelActive()
    {
        yield return new WaitForSeconds(timeToSpawn);
        if (wavesToSpawn == 1) SpawnWave(enemiesToSpawn);
        else
        {
            int actualSpawn = UnityEngine.Random.Range(minSizeWave, maxSizeWave);
            SpawnWave(actualSpawn);
            StartCoroutine(LevelActive());
        }
        wavesToSpawn--;
    }

    public void StartLevel()
    {
        if (enemiesActive <= 0)
        {
            actualLevel++;
            if (actualLevel < levels.Length)
            {
                enemiesActive = levels[actualLevel].countEnemy;
                enemiesToSpawn = levels[actualLevel].countEnemy;
                wavesToSpawn = levels[actualLevel].countWaves;
                minSizeWave = levels[actualLevel].minSizeWave;
                maxSizeWave = levels[actualLevel].maxSizeWave;
                timeToSpawn = levels[actualLevel].timeToSpawn;
                StartCoroutine(LevelActive());
            }
            else print("Ganaste");
        }
    }
    [Serializable] public class Level
    {
        public int countEnemy, countWaves, minSizeWave, maxSizeWave;
        public float timeToSpawn;
    }
}
