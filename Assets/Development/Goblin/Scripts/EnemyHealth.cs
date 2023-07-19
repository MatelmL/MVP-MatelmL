using UnityEngine;

namespace Goblin
{
    public class EnemyHealth : MonoBehaviour, ITakeDamage, IAddForce
    {
        private EnemyState state;
        public Rigidbody chestRb;

        private void Awake()
        {
            state = GetComponent<EnemyState>();
        }

        public float health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void TakeDamage(float damageAmount)
        {
            state.StartDying();
        }
        
        public void AddForce(float magnitude, Transform origin, float radius)
        {
            chestRb.AddForce( ((transform.position - origin.position).normalized + Vector3.up) * magnitude,  ForceMode.Impulse);
        }
    }
}
