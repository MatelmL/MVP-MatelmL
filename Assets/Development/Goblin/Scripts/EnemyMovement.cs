using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

namespace Goblin
{
    public class EnemyMovement : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;

        public UnityEvent OnEnemyAttack;

        private Queue<Transform> path;

        private EnemyState state;

        private Transform destination;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            state = GetComponent<EnemyState>();
        }

        public void Initialize()
        {
            path = Paths.Instance.GetRandomPath();
            GetComponent<Collider>().enabled = true;
            NextWaypoint();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.tag);
            if (state.currentState != GoblinState.Moving) return;
            if (other.CompareTag("DeadZone"))
            {
                Debug.Log("DeadZone");
                EnemyPool.Instance.ReturnEnemy(gameObject);
            }
            if (GameManager.Instance.lose) return;
            if (other.CompareTag("Waypoint"))
            {
                if (destination.position == other.transform.position)
                    NextWaypoint();
            }
            else if (other.CompareTag("Door"))
            {
                OnEnemyAttack.Invoke();
                navMeshAgent.Stop();
                gameObject.transform.LookAt(other.transform.position);
            }
            
        }
        void NextWaypoint()
        {

            if (path.Count > 0)
            {
                destination = path.Dequeue();
                navMeshAgent.SetDestination(destination.position);
            }
            else
            {
                navMeshAgent.SetDestination(Paths.Instance.DoorPosition.position);
            }
        }

        void Lose()
        {
            state.StartMoving();
            navMeshAgent.Resume();
            navMeshAgent.SetDestination(Paths.Instance.DefeatPosition.position);
        }
        private void OnEnable()
        {
            Door.OnDoorDie += Lose;
        }
        private void OnDisable()
        {
            Door.OnDoorDie -= Lose;
        }
    }
}
