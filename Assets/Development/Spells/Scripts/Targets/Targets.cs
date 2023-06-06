using UnityEngine;

namespace Spells
{
    public abstract class Targets
    {
        public SOSpell spellData; // Set by parent, use to get spell params from the SO
        public abstract Collider[] GetTargets(Collision other);
    }
}