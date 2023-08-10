using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Spells
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(ResetOnGameRestart))]
    [RequireComponent(typeof(Rigidbody))]
    public class Proyectile : SpellCarrier, IReset
    {
        public ParticleSystem projectileVFX;

        public float lifetime = 5f;
        private Rigidbody rb;
        private float speed;
        [SerializeField] float distanceToVFX;
        public UnityEvent OnTrigger;
        bool impact = false;
        private void Awake()
        {
            base.Awake();
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
            impact = false;
            StartCoroutine(Lifetime());
            Invoke(nameof(StartProjectileVFX), distanceToVFX / speed);
            rb.velocity = transform.forward * speed;
        }

        IEnumerator Lifetime()
        {
            yield return new WaitForSeconds(lifetime);
            if (!impact)
                ReturnToQueue();
        }

        private void OnTriggerEnter(Collider other)
        {
            Impact(other);
        }

        private void Impact(Collider other)
        {
            impact = true;
            OnTrigger?.Invoke();
            ApplyEffects(targets.GetTargets(other));
            projectileVFX.Stop();
            StartHitVfx();
            rb.velocity = Vector3.zero;
            ReturnToQueue();
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

