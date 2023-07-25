using Spells;
using UnityEngine;

[RequireComponent(typeof(ResetOnGameRestart))]
public class ExplosiveBarrel : SpellCarrier, IExplode, IReset
{
    public SOSpell spellData;
    private void Awake()
    {
        Reset();
        GetSpellComponents();
        spell = spellData.GetInstance(transform);
    }
    
    public void Reset()
    {
        if (spell.hitVFX)
        {
            spell.hitVFX.time = 0;
            spell.hitVFX.Stop();   
        }
        gameObject.SetActive(true);
    }

    public void Explode()
    {
        if (spell.hitVFX) spell.hitVFX.Play();
        ApplyEffects(targets.GetTargets(collider));
        gameObject.SetActive(false);
    }

    protected override void OnHitVfxEnd() {}
}
