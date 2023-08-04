using System;
using UnityEngine;

namespace Goblin
{
    public class EnemyHealth : MonoBehaviour, ITakeDamage, IAddForce, ICaught
    {
        private EnemyState state;
        public Rigidbody chestRb;
        private EnemyController enemyController;

        private void Awake()
        {
            state = GetComponent<EnemyState>();
            enemyController = GetComponent<EnemyController>();
        }

        public float health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void TakeDamage(float damageAmount)
        {
            state.StartDying();
        }
        
        public void AddForce(float magnitude, Transform origin, float radius)
        {
            chestRb.AddForce( ((transform.position - origin.position).normalized + Vector3.up) * magnitude,  ForceMode.Impulse);
        }

        public Rigidbody GetRigidbody()
        {
            return chestRb;
        }

        public void OnCaught(Action onDeathCallback)
        {
            enemyController.onDisable += onDeathCallback;
            state.StartDying();
        }
    }
}
