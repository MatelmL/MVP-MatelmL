using UnityEngine;
using System;


public class GateHealth : MonoBehaviour, ITakeDamage, IReset
{
    public int maxLife;
    public int specialNumber;

    public static event Action OnDeath;
    public static event Action<float> OnDamageTaken;
    public static event Action OnSpecialNumberReached;

    [SerializeField] float currentLife;

    private bool eventTriggered;

    public float health { get => currentLife; set => currentLife = value;}

    private void Awake()
    {
        currentLife = maxLife;
        eventTriggered = false;
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
            CheckSpecialNumberReached();
        }
    }

    public void ResetLife()
    {
        currentLife = maxLife;
        eventTriggered = false;
    }

    private void CheckSpecialNumberReached()
    {
        if(currentLife <= specialNumber && !eventTriggered)
        {
            eventTriggered = true;
            OnSpecialNumberReached?.Invoke();
        }
    }
}
