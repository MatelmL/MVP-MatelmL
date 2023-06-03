using System;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public GameObject wandTip;
    public SOSpell heldSpell;
    public GameObject heldSpellVFX;
    public void OnFinishDrawing(string SpellName)
    {
        SOSpell spell = SpellList.instance.GetSpell(SpellName);
        EnableSpellVFX(spell);
    }
    private void EnableSpellVFX(SOSpell spell)
    {
        if (spell.heldSpellVFX == null) return; 
        heldSpellVFX = Instantiate(spell.heldSpellVFX, wandTip.transform.position, wandTip.transform.rotation);
        heldSpellVFX.transform.parent = wandTip.transform;
    }

    public void onShoot()
    {
        if (heldSpell == null) return;
        DisableSpellVFX();
        GameObject proyectile = Instantiate(heldSpell.proyectile, wandTip.transform.position, wandTip.transform.rotation);
        Proyectile ProyectileComponent = proyectile.GetComponent<Proyectile>();
        ProyectileComponent.Init(heldSpell.proyectileSpeed, heldSpell.onImpact);
        heldSpell = null;
    }
    private void DisableSpellVFX()
    {
        if (heldSpellVFX == null) return;
        Destroy(heldSpellVFX);
    }
    
}
