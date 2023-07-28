using Spells;
using UnityEngine;

public class SingleTarget : Targets
{
    public override Collider[] GetTargets(Collider other)
    {
        return new[] { other };
    }
}