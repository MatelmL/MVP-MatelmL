using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    //sacar animator despues de implementar maquina de estados
    [SerializeField] private Animator animator;

    private Rigidbody[] rigidbodies;

    void Start()
    {
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        SetEnabled(false);
    }

    void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = isKinematic;
        }

        //sacar animator despues de implementar maquina de estados
        animator.enabled = !enabled;
    }

    //para testear
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetEnabled(true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetEnabled(false);
        }
    }
}
