using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{
   // [SerializeField] float timeSpawn;
    [SerializeField] Transform firstDestination;
  //  bool isActive = true;
    private void Start()
    {
   //     StartCoroutine(SpawnCoroutine());
    }

    public void SpawnEnemy()
    {
        GameObject goblinObject = PoolGoblin.instance.GetNewGoblin();
        Goblin goblinScript = goblinObject.GetComponent<Goblin>();
        goblinObject.transform.position = this.transform.position;
        goblinObject.SetActive(true);
        goblinScript.ToggleState();
        goblinScript.agent.SetDestination(firstDestination.position);
        goblinScript.GoFinalDirection();
    }

    /*
    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(timeSpawn);
        if (isActive)
        {
            SpawnEnemy();
            StartCoroutine(SpawnCoroutine());
        }
    }
    */
    //void StopSpawn() => CancelInvoke("SpawnEnemy");
    
    private void OnEnable()
    {
        //GateHealth.OnDeath += StopSpawn;
     //   GameManager.StartGameSE += () => StartCoroutine(SpawnCoroutine());
    }

    private void OnDisable()
    {
       // GateHealth.OnDeath -= StopSpawn;
    //    GameManager.StartGameSE -= () => StartCoroutine(SpawnCoroutine());
    }
}
