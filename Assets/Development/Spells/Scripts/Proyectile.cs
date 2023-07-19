using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
    [RequireComponent(typeof(Rigidbody))]
    public class Proyectile : MonoBehaviour
    {
        Targets targets;
        Effect[] effects;
        private SOSpell.Instance spell; // Spell object this projectile belongs to. 
        public float lifetime = 5f;
        public ParticleSystem hitVFX;
        private Rigidbody rb;
        private float speed;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void Init(float speed, SOSpell.Instance spell)
        {
            this.speed = speed;
            targets = GetComponent<Targets>();
            effects = GetComponents<Effect>();
            SetSpell(spell);
            gameObject.SetActive(false);
        }

        public void OnEnable()
        {
            StartCoroutine(Lifetime());
            rb.velocity = transform.forward * speed;
        }

        public IEnumerator Lifetime()
        {
            yield return new WaitForSeconds(lifetime);
            if (!hitVFX.isPlaying) ReturnToQueue();
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
        private void OnCollisionEnter(Collision other)
        {
            Effects(other);
        }

        private void Effects(Collision other)
        {
            Collider[] hits = targets.GetTargets(other);
            foreach (var hit in hits)
            {
                foreach (var effect in effects)
                {
                    Debug.Log(effect.GetType());
                    effect.Apply(hit);
                }
            }

            StartCoroutine(StartVfx());
        }

        private void ReturnToQueue()
        {
            SpellList.instance.ReturnSpell(spell);
            gameObject.SetActive(false);
        }
        
        public IEnumerator StartVfx()
        {
            if (hitVFX)
            {
                hitVFX.Play();
                yield return new WaitForSeconds(hitVFX.main.duration + 1f);
                hitVFX.Stop();
            } 
            ReturnToQueue();
        }

    }
}

