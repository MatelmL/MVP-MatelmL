using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] float timeSpawn;
    [SerializeField] Transform firstDestination;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", timeSpawn, timeSpawn);
    }

    void SpawnEnemy()
    {
        GameObject goblinObject = PoolGoblin.instance.GetNewGoblin();
        Goblin goblinScript = goblinObject.GetComponent<Goblin>();
        goblinObject.transform.position = this.transform.position;
        goblinObject.SetActive(true);
        goblinScript.ToggleState();
        goblinScript.agent.SetDestination(firstDestination.position);
        goblinScript.GoFinalDirection();
    }

}
