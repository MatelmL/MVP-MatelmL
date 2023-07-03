using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class GateHealth : MonoBehaviour, ITakeDamage, IReset
{
    public int maxLife;

    public UnityEvent<float> OnDamageTaken;
    public UnityEvent<float> OnSpecialNumberReached;

    public static event Action OnDeath;

    public float health { get => currentLife; set => currentLife = value; }

    [SerializeField] float currentLife;

    [SerializeField] List<int> specialNumbers = new List<int> { 75, 50, 25 };
    private List<int> triggeredSpecialNumbers = new List<int>();

    private void Awake()
    {
        currentLife = maxLife;
    }

    public void TakeDamage(float damageAmount)
    {
        currentLife -= damageAmount;

        if(currentLife <= 0)
        {
            currentLife = 0;
            OnDeath?.Invoke();
        }
        else
        {
            // En caso de necesitarse verificar el evento incluso en la muerte, ponerlo fuera del if y sacarla el else
            OnDamageTaken?.Invoke(currentLife);
            CheckSpecialNumberReached(specialNumbers);
        }
    }

    public void ResetLife()
    {
        currentLife = maxLife;
    }

    private void CheckSpecialNumberReached(List<int> specialNumbers)
    {
        foreach (int specialNumber in specialNumbers)
        {
            if (currentLife <= specialNumber && !triggeredSpecialNumbers.Contains(specialNumber))
            {
                triggeredSpecialNumbers.Add(specialNumber);
                OnSpecialNumberReached?.Invoke(specialNumber);
            }
        }
    }
}
