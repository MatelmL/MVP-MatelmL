using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    public float timeSpawn;
    public int sizeWave;
    //para parar el spawneo de enemigos poner booleando en false
    bool isActive = true;
    Spawner[] spawners;
    void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
        // esto esta en el start pero yo lo pondria en un evento llamado StartGame
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(timeSpawn);
        if (isActive)
        {
            SpawnWave();
            StartCoroutine(SpawnCoroutine());
        }
    }

    void SpawnWave()
    {
        List<Spawner> spawnersActive = spawners.ToList();
        for (int i = 0; i < sizeWave; i++)
        {
            int randomSpawn = Random.Range(0, spawnersActive.Count);
            spawnersActive[randomSpawn].SpawnEnemy();
            spawnersActive.Remove(spawnersActive[randomSpawn]);
        }
    }
}
