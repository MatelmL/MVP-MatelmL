using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpellList : MonoBehaviour
{
    [SerializeField] SOSpell[] spells;
    private Dictionary<string, Queue<SOSpell>> spellQueues = new();
    public static SpellList instance;
    public int SpellQueueSize = 4;
    private void Awake()
    {
        Singleton();
        LoadSpells();
    }

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void LoadSpells()
    {
        spells = Resources.LoadAll<SOSpell>("Spells");
        foreach (SOSpell spell in spells)
        {
            // add all spells to queue
            Queue<SOSpell> spellQueue = new Queue<SOSpell>();
            foreach (int i in Enumerable.Range(0, 4))
            {
                SOSpell newSpell = Instantiate(spell);
                newSpell.Init();
                spellQueue.Enqueue(newSpell);
            }
        }
    }
    
    
    public SOSpell GetSpell(string name)
    {
        if (spellQueues.ContainsKey(name))
        {
            return spellQueues[name].Dequeue();
        }
        else
        {
            throw new Exception("Spell not found");
        }
    }
    
    public void ReturnSpell(SOSpell spell)
    {
        if (spellQueues.ContainsKey(spell.name))
        {
            spellQueues[spell.name].Enqueue(spell);
        }
        else
        {
            throw new Exception("Spell not found");
        }
    }
}
