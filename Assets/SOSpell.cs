using UnityEngine;

// Scriptable object
[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class SOSpell : ScriptableObject
{
    // Spells should be stored in the Resources/Spells folder
    public string name;
    public GameObject proyectile;
    public float proyectileSpeed;
    public GameObject onImpact;
    public float radius;
    public float knockback;
    public GameObject heldSpellVFX;

    public void Init()
    {
        proyectile = Instantiate(proyectile);
        onImpact = Instantiate(onImpact);
        heldSpellVFX = Instantiate(heldSpellVFX);
        proyectile.GetComponent<Proyectile>().Init(proyectileSpeed, onImpact);
    }
}
