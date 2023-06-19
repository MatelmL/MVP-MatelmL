using UnityEngine;

public class InteractableObject : MonoBehaviour, ITakeDamage
{
    private float health;

    private void Start()
    {
        health = 1;
    }

    float ITakeDamage.health { get => health; set => health = value; }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(1);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}