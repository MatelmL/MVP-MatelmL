using UnityEngine;

namespace Spells
{
    public abstract class Effect
    {
        public SOSpell spellData; // Set by parent, use to get spell params rom the SO

        public abstract void Apply(Collider target);
    }
}