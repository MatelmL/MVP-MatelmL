using Spells;
using UnityEngine;

[RequireComponent(typeof(ResetOnGameRestart))]
public class ExplosiveBarrel : SpellCarrier, IExplode, IReset
{
    public SOSpell spellData;
    private void Awake()
    {
        GetSpellComponents();
        spell = spellData.GetInstance(transform);
    }

    public void Reset()
    {
        RestartHitVfx();
        gameObject.SetActive(true);
    }

    public void Explode(Collider collider)
    {
        StartHitVfx();
        ApplyEffects(targets.GetTargets(collider));
        gameObject.SetActive(false);
    }
}
