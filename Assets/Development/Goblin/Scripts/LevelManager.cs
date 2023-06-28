using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LevelManager : MonoBehaviour
{
    public bool isActive = true;
    Spawner[] spawners;
    public static LevelManager instance;

    [NonSerialized] public int enemiesActive = 0;
    int actualLevel = -1;
    int actualWave;
    float timeToSpawn;
    [SerializeField] float timeToChangeLevel;
    [SerializeField] Level[] levels;
    public static Action NextLevel;

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
        SpawnWave(level.waves[actualWave]);
        actualWave++;
        yield return new WaitForSeconds(timeToSpawn);
        if (actualWave < level.waves.Length) StartCoroutine(LevelActive(level));
    }

    public void StartLevel()
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

    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(timeToChangeLevel);
        StartLevel();
        print("CAMBIE DE NIVEL");
    }

    private void OnEnable()
    {
        NextLevel += () => StartCoroutine(ChangeLevel());
    }

    private void OnDisable()
    {
        NextLevel -= () => StartCoroutine(ChangeLevel());
    }

    [Serializable] public class Level
    {
        public int[] waves;
        public float timeToSpawn;
    }
}
