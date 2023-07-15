using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using System.IO;
using Goblin;
using GrayBoxing;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public UnityEvent OnEnemyAttack;

    private Queue<Transform> path;

    private EnemyState state;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        state = GetComponent<EnemyState>();
    }
    
    public void Initialize()
    {
        path = Paths.Instance.GetRandomPath();
        NextWaypoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(state.currentState != GoblinState.Moving) return;
        if (GameManager.Instance.lose) return;
        if (other.CompareTag("Waypoint"))
        {
            if (navMeshAgent.destination == other.transform.position)
            NextWaypoint();
        }
        else if (other.CompareTag("Door"))
        {
            OnEnemyAttack.Invoke();
        }
    }
    void NextWaypoint()
    {

        if(path.Count > 0)
        {
            navMeshAgent.SetDestination(path.Dequeue().position);
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
