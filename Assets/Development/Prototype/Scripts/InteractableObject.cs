using UnityEngine;

public class InteractableObject : MonoBehaviour, ITakeDamage
{
    private int health;

    private void Start()
    {
        health = 1;
    }

    int ITakeDamage.health { get => health; set => health = value; }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(1);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}