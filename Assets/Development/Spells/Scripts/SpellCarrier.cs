using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace Spells
{
    [RequireComponent(typeof(Collider))]
    public abstract class SpellCarrier : MonoBehaviour
    {
        protected  SOSpell.Instance spell; // Spell object this belongs to. 
        protected Targets targets;
        protected Effect[] effects;
        protected Collider collider;

        private void Awake()
        {
            collider = GetComponent<Collider>();
        }

        protected void GetSpellComponents()
        {
            targets = GetComponent<Targets>();
            effects = GetComponents<Effect>();
        }
        public void SetSpell(SOSpell.Instance spell)
        {
            this.spell = spell;
            targets.spellData = spell.spellData;
            foreach (var effect in effects)
            {
                effect.spellData = spell.spellData;
            }
        }
        protected void ApplyEffects(Collider[] hits)
        {
            foreach (var hit in hits)
            {
                if (hit == collider) continue; // Ignore self.
                foreach (var effect in effects)
                {
                    Debug.Log(effect.GetType());
                    effect.Apply(hit);
                }
            }
        }
        
        protected void StartHitVfx()
        {
            if (spell.hitVFX)
            {
                spell.hitVFX.time = 0;
                spell.hitVFX.transform.position = transform.position;
                spell.hitVFX.Play();
            } 
        }

        protected void RestartHitVfx()
        {
            if (spell.hitVFX)
            {
                spell.hitVFX.time = 0;
                spell.hitVFX.Stop();   
            }
        }
    }
}
