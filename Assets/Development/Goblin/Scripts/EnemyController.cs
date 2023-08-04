using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Goblin
{
    public class EnemyController : MonoBehaviour
    {
        EnemyState state;
        EnemyMovement movement;
        EnemyTweenAnimations tweenAnimations;
        public Action onDisable;

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

        private void OnDisable()
        {
            onDisable?.Invoke();
            onDisable = null; 
        }

        public void ReturnEnemy()
        {
            WaveManager.instance.EnemieDie();
            EnemyPool.Instance.ReturnEnemy(this);
        }
    }   
}
