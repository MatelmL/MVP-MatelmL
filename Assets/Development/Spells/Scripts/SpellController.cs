using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Spells
{
    public class SpellController : MonoBehaviour
    {
        public GameObject wandTip;
        public SOSpell.Instance heldSpell;
        [HideInInspector] public GameObject heldSpellVFX;
        public static SpellController instance;

        public bool debug = false;
        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(this);
        }


        private void Start()
        {
            if (debug) heldSpell = SpellList.instance.GetSpell("tornado");
        }

        public void OnFinishDrawing(string SpellName)
        {
            Debug.Log("Casted" + SpellName);
            heldSpell = SpellList.instance.GetSpell(SpellName);
            EnableSpellVFX();
        }

        private void EnableSpellVFX()
        {
            if (heldSpell.heldSpellVFX == null) return; 
            heldSpellVFX.transform.parent = wandTip.transform;
            heldSpellVFX.SetActive(true);
        }

        public void Shoot()
        {
            if (heldSpell == null) return;
            Debug.Log("Shooting spell" + heldSpell.spellData.name);
            DisableSpellVFX();
            heldSpell.proyectile.transform.position = wandTip.transform.position;
            heldSpell.proyectile.transform.rotation = wandTip.transform.rotation;
            heldSpell.proyectile.SetActive(true);
            if (!debug) heldSpell = null;
        }

        private void DisableSpellVFX()
        {
            if (!heldSpellVFX) return;
            heldSpellVFX.transform.parent = null;
            heldSpellVFX.SetActive(false);
        }
    }

}