using UnityEngine;

namespace Spells
{
    public class Explosion : Effect
    {
        public override void Apply(Collider target)
        {
            addForce(target);
            chainReacion(target);
        }

        private void addForce(Collider target)
        {
            IAddForce addForce = target.GetComponent<IAddForce>();
            if (addForce == null) return;
            addForce.AddForce(spellData.knockback, transform, spellData.radius);

        }

        private void chainReacion(Collider target)
        {
            // IExplode explode = target.GetComponent<IExplode>();
            // if (explode == null) return;
            // explode.explode();
        }
    }
}