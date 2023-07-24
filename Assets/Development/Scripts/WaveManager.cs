using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;

    public int wave;

    public int restWaves;

    public EnemySpawner[] spawners;

    public int enemiesInWave;

    public int enemiesAlive;

    public float timeBetweenWaves = 10f;

    public float timeBetweenEnemies = 1f;

    public Action<int,int> OnWaveClear;

    private void Awake()
    {
        Instance = this;
        wave = 1;
        spawners = FindObjectsOfType<EnemySpawner>();
        StartWave();
        
    }
    private void Start()
    {
        UpdateUI();
    }
    public void StartWave()
    {
        //curva de dificultad
        enemiesInWave = 100 / (-wave - 11) + 11;

        enemiesAlive = enemiesInWave;

        StartCoroutine(Spawn());

    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < enemiesInWave; i++) {
            yield return new WaitForSeconds(timeBetweenEnemies);
            spawners[UnityEngine.Random.Range(0,spawners.Length)].Spawn();
        }
    }

    public void WaveClear()
    {
        wave++;
        if (wave % restWaves != 0)
        {
            Invoke("StartWave", timeBetweenWaves);
        }
        else
        {
            //startGobling
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        int nextRest = (int)Math.Ceiling((float)wave / restWaves);
        OnWaveClear.Invoke(wave, restWaves * nextRest);
    }

    public void EnemieDie()
    {
        enemiesAlive--;
        if(enemiesAlive == 0)
        {
            WaveClear();
        }
    }
}
