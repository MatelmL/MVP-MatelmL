using System;
using System.Collections;
using System.Collections.Generic;
using Goblin;
using UnityEngine;

public class WaveManager : MonoBehaviour, IReset
{
    public static WaveManager instance;

    public int wave;

    public int restWaves;

    public EnemySpawner[] spawners;

    public int enemiesInWave;
    public int enemiesAlive;

    public float timeBetweenWaves = 10f;
    public float timeBetweenEnemies = 1f;

    public static Action<int,int> OnWaveClear;

    bool isSpawning = false;
    bool waveActive = false;

    private void Awake()
    {
        instance = this;
        wave = 1;
        spawners = FindObjectsOfType<EnemySpawner>();
        //StartWave();
    }
    private void Start()
    {
        UpdateUI();
        //StartCoroutine(CheckWaveFinish());
    }
    public void StartWave()
    {
        waveActive = true;
        //curva de dificultad
        enemiesInWave = 100 / (-wave - 11) + 11;
        enemiesAlive = enemiesInWave;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        isSpawning = true;
        for (int i = 0; i < enemiesInWave; i++) {
            yield return new WaitForSeconds(timeBetweenEnemies);
            spawners[UnityEngine.Random.Range(0,spawners.Length)].Spawn();
        }
        isSpawning = false;
    }

    public void WaveClear()
    {
        waveActive = false;
        wave++;
        if (wave % restWaves != 0)
        {
            Invoke(nameof(StartWave), timeBetweenWaves);
        }
        else
        {
            GameManager.Instance.StartGobling();
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        int nextRest = (int)Math.Floor((float)wave / restWaves) + 1;
        OnWaveClear?.Invoke(wave, restWaves * nextRest);
    }

    public void EnemieDie()
    {
        enemiesAlive--;
        if(GameManager.Instance.lose) return;
        if (enemiesAlive == 0)
        {
            WaveClear();
        }
        else
        {
            StartCoroutine(CheckWaveFinish());
        }
    }

    public void Reset()
    {
        wave = 1;
        waveActive = false;
        UpdateUI();
        for (int i = 0; i < transform.childCount; i++)
        {
            EnemyPool.Instance.ReturnEnemy(transform.GetChild(i).GetComponent<EnemyController>());
        }
    }
    IEnumerator CheckWaveFinish()
    {
        yield return new WaitForSeconds(5f);
        bool waveBug = true;
        if(!waveActive) yield break;
        if(isSpawning) yield break;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                waveBug = false;
                break;
            }
        }
        if (waveBug) WaveClear();
    }
}
