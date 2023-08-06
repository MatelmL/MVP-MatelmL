using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ResetOnGameRestart))]
public class Door : MonoBehaviour,ITakeDamage, IReset
{

    public static Action OnDoorDieAction;
    public UnityEvent OnDoorDie;
    public UnityEvent<float, float> OnDamageTaken;

    public float maxHealth;
    public float health { get ; set; }

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        OnDamageTaken?.Invoke(health, maxHealth);

        if (health <= 0)
        {
            OnDoorDieAction?.Invoke();
            OnDoorDie?.Invoke();
            gameObject.SetActive(false);
        }  
    }
}
