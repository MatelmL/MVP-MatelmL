using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Die()
    {
        Debug.Log("Eh Morido");
    }
    public void TakeDamage(float currentLife)
    {
        Debug.Log("Mi vida en este preciso momento es " + currentLife);
    }
    public void SpecialNumber(float specialNumber)
    {
        Debug.Log("El verdadero numero " + specialNumber);
    }

    private void OnEnable()
    {
         GateHealth.OnDeath += Die;
         GateHealth.OnDamageTaken += TakeDamage;
         GateHealth.OnSpecialNumberReached += SpecialNumber;
    }

     private void OnDisable()
     {
         GateHealth.OnDeath -= Die;
         GateHealth.OnDamageTaken -= TakeDamage;
         GateHealth.OnSpecialNumberReached -= SpecialNumber;
     }
}
