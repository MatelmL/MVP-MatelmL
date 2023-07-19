using UnityEngine;
using UnityEngine.Events;
using System;
namespace GrayBoxing
{
    public class GameManager : MonoBehaviour
    {
        public UnityEvent StartGameUE;

        //solo esta para testear, hay que sacar esto...
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P)) StartGameUE?.Invoke();
        }

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
}
