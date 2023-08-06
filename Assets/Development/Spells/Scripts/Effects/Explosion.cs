using UnityEngine;

namespace Spells
{
    public class Explosion : Effect
    {
        public override void Apply(Collider target)
        {
            addForce(target);
            chainReaction(target);
        }
        //TODO mover a clase AddForce y dejar solo el metodo chainReaction (asi se puede hacer explotar el barril con el basico por ejemplo)
        private void addForce(Collider target)
        {
            IAddForce addForce = target.GetComponent<IAddForce>();
            if (addForce == null) return;
            addForce.AddForce(spellData.force, transform, spellData.radius);

        }

        private void chainReaction(Collider target)
        {
            IExplode explode = target.GetComponent<IExplode>();
            if (explode == null) return;
            explode.Explode(target);
        }
    }
}