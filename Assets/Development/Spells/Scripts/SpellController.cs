using UnityEngine;

namespace Spells
{
    public class SpellController : MonoBehaviour
    {
        public GameObject wandTip;
        public SOSpell.Instance heldSpell;
        [HideInInspector] public GameObject heldSpellVFX;
        
        public void OnFinishDrawing(string SpellName)
        {
            heldSpell = SpellList.instance.GetSpell(SpellName);
            EnableSpellVFX();
        }
        private void EnableSpellVFX()
        {
            if (heldSpell.heldSpellVFX == null) return; 
            heldSpellVFX.transform.parent = wandTip.transform;
            heldSpellVFX.SetActive(true);
        }

        public void onShoot()
        {
            if (heldSpell == null) return;
            DisableSpellVFX();
            heldSpell.proyectile.transform.position = wandTip.transform.position;
            heldSpell.proyectile.transform.rotation = wandTip.transform.rotation;
            heldSpell.proyectile.SetActive(true);
            heldSpell = null;
        }
        private void DisableSpellVFX()
        {
            if (heldSpellVFX == null) return;
            heldSpellVFX.transform.parent = null;
            heldSpellVFX.SetActive(false);
        }
    
    }

}