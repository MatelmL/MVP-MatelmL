using System;
using UnityEditor;
using UnityEngine;

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
        public float knockback;
        public GameObject heldSpellVFX;
        public GameObject hitVFX;
        public GameObject hitSFX;

        public class Instance
        {
            public SOSpell spellData;
            public GameObject proyectile;
            public GameObject heldSpellVFX;
            public GameObject hitVFX;
            public GameObject hitSFX;
        }
        public Instance GetInstance(Transform parent)
        {
            Instance instance = new Instance();
            instance.spellData = this;
            InstantiateVFX(instance, parent);
            InstantiateProjectile(instance, parent);
            return instance;
        }

        private void InstantiateVFX(Instance instance, Transform parent)
        {
            if (heldSpellVFX == null) return;
            instance.heldSpellVFX = Instantiate(heldSpellVFX, parent: parent);
        }

        private void InstantiateProjectile(Instance instance, Transform parent)
        {
            instance.proyectile = Instantiate(proyectile, parent: parent);
            instance.proyectile.GetComponent<Proyectile>().Init(proyectileSpeed, instance);
            instance.proyectile.SetActive(false);
        }
    }
}

