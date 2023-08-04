using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spells
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
    public class SOSpell : ScriptableObject
    {
        // Spells should be stored in the Resources/Spells folder
        public string name;
        public GameObject proyectile;
        public float proyectileSpeed;
        public float radius;
        [FormerlySerializedAs("knockback")] public float force;
        public GameObject heldSpellVFX;
        public GameObject hitVFX;
        public AudioClip castSFX;

        public class Instance
        {
            public SOSpell spellData;
            public GameObject proyectile;
            public ParticleSystem heldSpellVFX;
            public ParticleSystem hitVFX;
        }
        public Instance GetInstance(Transform parent)
        {
            Instance instance = new Instance();
            instance.spellData = this;
            InstantiateHeldVFX(instance, parent);
            InstantiateHitVFX(instance, parent);
            InstantiateProjectile(instance, parent);
            return instance;
        }

        private void InstantiateHeldVFX(Instance instance, Transform parent)
        {
            if (heldSpellVFX == null) return;
            GameObject heldSpellInstance = Instantiate(heldSpellVFX, parent: parent);
            instance.heldSpellVFX = heldSpellInstance.GetComponent<ParticleSystem>();
        }
        private void InstantiateHitVFX(Instance instance, Transform parent)
        {
            if (hitVFX == null) return;
            GameObject heldSpellInstance = Instantiate(hitVFX, parent: parent);
            instance.hitVFX = heldSpellInstance.GetComponent<ParticleSystem>();
        }

        private void InstantiateProjectile(Instance instance, Transform parent)
        {
            if (proyectile == null) return;
            instance.proyectile = Instantiate(proyectile, parent: parent);
            instance.proyectile.GetComponent<Proyectile>().Init(proyectileSpeed, instance);
            instance.proyectile.SetActive(false);
        }
    }
}

