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

        private Collider _collider;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            state = GetComponent<EnemyState>();
            _collider = GetComponent<Collider>();
        }

        public void Initialize()
        {
            path = Paths.Instance.GetRandomPath();
            _collider.enabled = true;
            NextWaypoint();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.tag);
            if (state.currentState != GoblinState.Moving) return;
            if (other.CompareTag("DeadZone"))
            {
                Debug.Log("DeadZone");
                EnemyPool.Instance.ReturnEnemy(GetComponent<EnemyController>());
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
                LookAtDoor();
            }

        }

        public void LookAtDoor()
        {
            gameObject.transform.LookAt(Paths.Instance.DoorPosition.position);
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
            Door.OnDoorDieAction += Lose;
        }
        private void OnDisable()
        {
            Door.OnDoorDieAction -= Lose;
        }
    }
}
