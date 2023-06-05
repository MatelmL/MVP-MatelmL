using UnityEngine;
using UnityEngine.AI;

public class Goblin : MonoBehaviour
{
    public NavMeshAgent agent;
    Rigidbody rb;
    public Transform destination;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void ToggleState()
    {
        agent.enabled = !agent.enabled;
        rb.isKinematic = !rb.isKinematic;
    }
}
