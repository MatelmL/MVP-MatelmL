using System;
using UnityEngine;

public class Door : MonoBehaviour,ITakeDamage,IReset
{

    public static Action OnDoorDie;

    public float maxHealth;
    public float health { get ; set; }

    public void ResetLife()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health-= damageAmount;
        if(health <= 0)
        {
            OnDoorDie?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
