using Spells;
using UnityEngine;

[RequireComponent(typeof(ResetOnGameRestart))]
public class ExplosiveBarrel : SpellCarrier, IExplode, IReset
{
    public SOSpell spellData;
    private void Awake()
    {
        base.Awake();
        GetSpellComponents();
        spell = spellData.GetInstance(transform);
        SetSpell(spell);
    }

    public void Reset()
    {
        RestartHitVfx();
        gameObject.SetActive(true);
    }

    public void Explode(Collider collider)
    {
        Debug.Log("Explode " + collider + "| my collider " + this.collider);
        StartHitVfx();
        ApplyEffects(targets.GetTargets(collider));
        Debug.Log("termino de explotar");

        gameObject.SetActive(false);
    }
}
