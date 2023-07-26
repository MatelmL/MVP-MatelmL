using System.Collections;
using UnityEngine;

namespace Spells
{
    [RequireComponent(typeof(ResetOnGameRestart))]
    [RequireComponent(typeof(Rigidbody))]
    public class Proyectile : SpellCarrier, IReset
    {
        public ParticleSystem projectileVFX;

        public float lifetime = 5f;
        private Rigidbody rb;
        private float speed;
        [SerializeField] float timeToVFX;

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
            Invoke(nameof(StartProjectileVFX), timeToVFX);
            rb.velocity = transform.forward * speed;
        }

        IEnumerator Lifetime()
        {
            yield return new WaitForSeconds(lifetime);
            ReturnToQueue();
        }

        private void OnTriggerEnter(Collider other)
        {
            ApplyEffects(targets.GetTargets(other));
            projectileVFX.Stop();
            StartHitVfx();
            ReturnToQueue();
            rb.velocity = Vector3.zero;
        }

        private void ReturnToQueue()
        {
            SpellList.instance.ReturnSpell(spell);
            gameObject.SetActive(false);
        }
        
        private void StartProjectileVFX()
        {
            if (projectileVFX) projectileVFX.Play();
        }

        public void Reset()
        {
            RestartHitVfx();
            ReturnToQueue();
        }
    }
}

