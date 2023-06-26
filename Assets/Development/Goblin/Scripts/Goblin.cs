using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class Goblin : MonoBehaviour
{
    [NonSerialized] public NavMeshAgent agent;
    Rigidbody rb;

    Vector3 doorDestination;
    [SerializeField] Vector3 finalWaypoint;

    [SerializeField] float damage, timeAttack;
    
    Coroutine attackCorrutine;
    bool isAttacking = false;
    [SerializeField] Animator animator;
    private void Awake()
    {
        doorDestination = FindObjectOfType<GateHealth>().transform.position;
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
        GateHealth gate = other.GetComponent<GateHealth>();
        if (waypoint != null && this.isActiveAndEnabled) {
            agent.SetDestination(waypoint.newDestination.position);
            GoFinalDirection();
        }
        else if(gate != null && this.isActiveAndEnabled)
        {
            attackCorrutine = StartCoroutine(Attack(gate));
            isAttacking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GateHealth gate = other.GetComponent<GateHealth>();
        if (gate != null && this.isActiveAndEnabled)
        {
            animator.SetBool("Attack", false);
            StopCoroutine(attackCorrutine);
            isAttacking = false ;
        }
    }

    IEnumerator Attack(GateHealth gate)
    {
        gate.TakeDamage(damage);
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(timeAttack);
        if(isAttacking) attackCorrutine = StartCoroutine(Attack(gate));
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

    void finalPosition() => agent.SetDestination(doorDestination + finalWaypoint);

    public void GoblinDie()
    {
        ToggleState();
        SpawnManager.instance.enemiesActive--;
        SpawnManager.instance.SpawnWave();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GateHealth.OnDeath += finalPosition;
    }

    private void OnDisable()
    {
        GateHealth.OnDeath -= finalPosition;
    }
}
