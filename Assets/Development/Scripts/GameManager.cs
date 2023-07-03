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
}
