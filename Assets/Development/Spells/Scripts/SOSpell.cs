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
        public MonoScript targets;
        public MonoScript[] effects;

        public class Instance
        {
            public SOSpell spellData;
            public GameObject proyectile;
            public GameObject heldSpellVFX;
            public GameObject hitVFX;
            public GameObject hitSFX;
        }
        public Instance GetInstance()
        {
            Instance instance = new Instance();
            instance.spellData = this;
            InstantiateVFX(instance);
            InstantiateProjectile(instance);
            return instance;
        }

        private void InstantiateVFX(Instance instance)
        {
            if (heldSpellVFX == null) return;
            instance.heldSpellVFX = Instantiate(heldSpellVFX);
        }

        private void InstantiateProjectile(Instance instance)
        {
            instance.proyectile = Instantiate(proyectile);
            instance.proyectile.AddComponent(targets.GetType());
            foreach (var effect in effects)
            {
                instance.proyectile.AddComponent(effect.GetType());   
            }
            instance.proyectile.GetComponent<Proyectile>().Init(proyectileSpeed, instance);
            instance.proyectile.SetActive(false);
        }
    }
}

