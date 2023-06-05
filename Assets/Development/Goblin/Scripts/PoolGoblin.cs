using System.Collections.Generic;
using UnityEngine;

public class PoolGoblin : MonoBehaviour
{
    public List<GameObject> goblinsList;
    public int amount;
    public GameObject goblin;
    public static PoolGoblin instance;
    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this.gameObject);
        else instance = this;
        instanceEnemys();
    }

    void instanceEnemys()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newEnemy = Instantiate(goblin);
            newEnemy.SetActive(false);
            goblinsList.Add(newEnemy);
        }
    }

    public GameObject GetNewGoblin()
    {
        foreach (GameObject item in goblinsList) if (!item.activeInHierarchy) return item;
        return Instantiate(goblin);
    }
}
