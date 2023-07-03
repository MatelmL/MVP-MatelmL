using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform firstDestination;

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

}
