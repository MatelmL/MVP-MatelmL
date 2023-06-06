using UnityEngine;
using UnityEngine.AI;

namespace Spells
{
    public class Explosion : Effect
    {
        public override void Apply(Collider target)
        {
            // TODO: Move this to an interface IKnockback?
            disableNavmesh(target);
            addForce(target);
            chainReacion(target);
        }

        private void disableNavmesh(Collider target)
        {
            NavMeshAgent agent = target.GetComponent<NavMeshAgent>();
            if (agent == null) return;
            agent.enabled = false;
        }

        private void addForce(Collider target)
        {
            Rigidbody rb = target.GetComponent<Rigidbody>();
            if (rb == null) return;
            rb.isKinematic = false;
            rb.AddExplosionForce(spellData.knockback, spellData.proyectile.transform.position, spellData.radius);
        }

        private void chainReacion(Collider target)
        {
            // IExplode explode = target.GetComponent<IExplode>();
            // if (explode == null) return;
            // explode.explode();
        }
    }
}