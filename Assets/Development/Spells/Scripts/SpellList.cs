using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Spells
{
        
    public class SpellList : MonoBehaviour
    {
        [SerializeField] SOSpell[] spells;
        private Dictionary<string, Queue<SOSpell.Instance>> spellQueues = new();
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
                spellQueues.Add(spell.name, new Queue<SOSpell.Instance>());
                foreach (int i in Enumerable.Range(0, SpellQueueSize))
                {
                    spellQueues[spell.name].Enqueue(spell.GetInstance());
                }
            }
        }
        
        
        public SOSpell.Instance GetSpell(string name)
        {
            if (spellQueues.ContainsKey(name))
            {
                return spellQueues[name].Dequeue();
            }
            throw new Exception("Spell not found");
        }
        
        public void ReturnSpell(SOSpell.Instance spell)
        {
            if (spellQueues.ContainsKey(spell.spellData.name))
            {
                spellQueues[spell.spellData.name].Enqueue(spell);
            }
            else
            {
                throw new Exception("Spell not found");
            }
        }
    }
}
