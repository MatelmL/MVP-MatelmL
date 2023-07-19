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
            if (state.currentState != GoblinState.Moving) return;
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
            navMeshAgent.SetDestination(Paths.Instance.DefeatPosition.position);
        }

    }
}
