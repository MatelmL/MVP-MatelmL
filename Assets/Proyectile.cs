using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Proyectile : MonoBehaviour
{
    public GameObject onImpact;

    public void Init(float speed, GameObject onImpact)
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        this.onImpact = onImpact;
    }
    private void OnCollisionEnter(Collision other) {
        if (onImpact != null)
        {
            Instantiate(onImpact, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
