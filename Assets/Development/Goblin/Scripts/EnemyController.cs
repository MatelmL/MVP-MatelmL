using UnityEngine;

namespace Goblin
{
    public class EnemyController : MonoBehaviour
    {
        EnemyState state;
        EnemyMovement movement;
        EnemyTweenAnimations tweenAnimations;

        private void Awake()
        {
            state = GetComponent<EnemyState>();
            movement = GetComponent<EnemyMovement>();
            tweenAnimations = GetComponent<EnemyTweenAnimations>();
            tweenAnimations.onTweenEnd += ReturnEnemy;
        }
        

        public void OnSpawn()
        {
            transform.GetChild(1).localScale = Vector3.one;
            foreach (Transform t in transform)
            {
                t.localPosition = Vector3.zero;
            }
            state.StartMoving();
            movement.Initialize();
            gameObject.SetActive(true);
            
        }
        
        public void ReturnEnemy()
        {
            WaveManager.instance.EnemieDie();
            EnemyPool.Instance.ReturnEnemy(this);
        }
    }   
}
