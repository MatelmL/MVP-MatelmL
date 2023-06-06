using UnityEngine;

namespace Spells
{
    public class SphereTarget : Targets
    {
        public override Collider[] GetTargets(Collision other)
        {
            return Physics.OverlapSphere(other.GetContact(0).point, 1f);
        }
    }
}