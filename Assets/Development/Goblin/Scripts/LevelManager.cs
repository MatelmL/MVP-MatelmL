using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LevelManager : MonoBehaviour
{
    [NonSerialized] public int enemiesActive = 0;
     public bool isActive = true;
    Spawner[] spawners;
    public static LevelManager instance;
    [SerializeField] Level[] levels;
    public int actualLevel = -1;
    int actualWave;
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
            for (int i = 0; i < sizeWave; i++)
            {
                int randomSpawn = UnityEngine.Random.Range(0, spawnersActive.Count);
                spawnersActive[randomSpawn].SpawnEnemy();
                spawnersActive.Remove(spawnersActive[randomSpawn]);
            }
    }

    IEnumerator LevelActive(Level level)
    {
        yield return new WaitForSeconds(timeToSpawn);
        
        SpawnWave(level.waves[actualWave]);
        actualWave++;
        if(actualWave< level.waves.Length) StartCoroutine(LevelActive(level));
    }

    public void StartLevel()
    {
        if (enemiesActive <= 0)
        {
            actualLevel++;
            if (actualLevel < levels.Length)
            {
                actualWave = 0;
                foreach (var item in levels[actualLevel].waves) enemiesActive += item;
                timeToSpawn = levels[actualLevel].timeToSpawn;
                StartCoroutine(LevelActive(levels[actualLevel]));
            }
            else print("Ganaste");
        }
    }
    [Serializable] public class Level
    {
        public int[] waves;
        public float timeToSpawn;
    }

}
