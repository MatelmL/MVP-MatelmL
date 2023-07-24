using UnityEngine;

namespace Spells
{
    public class DealDamage : Effect
    {
        public override void Apply(Collider target)
        {
            Debug.Log("DealDamage: " + target.gameObject);
            ITakeDamage health = target.GetComponent<ITakeDamage>();
            if (health == null) return;
            health.TakeDamage(1);
        }
    }
}
