using UnityEngine;

namespace Spells
{
    [RequireComponent(typeof(Rigidbody))]
    public class Proyectile : MonoBehaviour
    {
        Targets targets;
        Effect[] effects;
        private SOSpell.Instance spell; // Spell object this projectile belongs to.
        public void Init(float speed, SOSpell.Instance spell)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
            targets = GetComponent<Targets>();
            effects = GetComponents<Effect>();
            SetSpell(spell);
            gameObject.SetActive(false);
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
        private void OnCollisionEnter(Collision other) {
            Collider[] hits = targets.GetTargets(other);
            foreach (var hit in hits)
            {
                foreach (var effect in effects)
                {
                    effect.Apply(hit);
                }
            }
            SpellList.instance.ReturnSpell(spell);
            gameObject.SetActive(false);
        }
    }
}

