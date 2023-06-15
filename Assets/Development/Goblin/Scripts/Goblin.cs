using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Goblin : MonoBehaviour
{
    public NavMeshAgent agent;
    Rigidbody rb;
    public Vector3 doorDestination;
    private void Awake()
    {
        doorDestination = FindObjectOfType<Door>().transform.position;
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void ToggleState()
    {
        agent.enabled = !agent.enabled;
        rb.isKinematic = !rb.isKinematic;
    }

    private void OnTriggerEnter(Collider other)
    {
        Waypoint waypoint = other.GetComponent<Waypoint>();
        if (waypoint != null) {
            agent.SetDestination(waypoint.newDestination.position);
            GoFinalDirection();
        }
    }

    //LLAMAR SIEMPRE QUE SE MUEVA AL GOBLIN DE LUGAR PARA VERIFICAR QUE SE PUEDA LLEGAR AL PROXIMO WAYPOINT (SI NO SE PUEDE IRA A LA PUERTA)
    public void GoFinalDirection()
    {
        if (!CheckPath())
            agent.SetDestination(doorDestination);
    }

    public bool CheckPath()
    {
        NavMeshPath path = agent.path;
        bool hasPath = agent.CalculatePath(agent.destination, path);
        if (!hasPath || path.status == NavMeshPathStatus.PathPartial || path.status == NavMeshPathStatus.PathInvalid) return false;
        else return true;
    }
}
