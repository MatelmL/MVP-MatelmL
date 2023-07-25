using UnityEngine;

namespace Spells
{
    public class SphereTarget : Targets
    {
        public override Collider[] GetTargets(Collider other)
        {
            return Physics.OverlapSphere(other.ClosestPoint(transform.position), spellData.radius);
        }
    }
}