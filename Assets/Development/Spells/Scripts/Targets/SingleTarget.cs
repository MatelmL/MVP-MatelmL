using Spells;
using UnityEngine;

public class SingleTarget : Targets
{
    public override Collider[] GetTargets(Collision other)
    {
        return new[] { other.collider };
    }
}