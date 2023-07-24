using System;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour,ITakeDamage,IReset
{

    public static Action OnDoorDie;
    public UnityEvent<float> OnDamageTaken;

    public float maxHealth;
    public float health { get ; set; }

    private void Start()
    {
        ResetLife();
    }

    public void ResetLife()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        OnDamageTaken?.Invoke(health);

        if (health <= 0)
        {
            OnDoorDie?.Invoke();
            gameObject.SetActive(false);
        }  
    }
}
