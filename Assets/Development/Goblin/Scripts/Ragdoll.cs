using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goblin
{
    public class Ragdoll : MonoBehaviour
    {
        private Rigidbody[] rigidbodies;
        private Collider[] colliders;

        private void Awake()
        {
            rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
            colliders = transform.GetComponentsInChildren<Collider>();
            SetEnabled(false);

        }



        public void SetEnabled(bool enabled)
        {
            bool isKinematic = !enabled;

            for (int i = 0; i < rigidbodies.Length; i++)
            {
                rigidbodies[i].isKinematic = isKinematic;
                colliders[i+1].enabled = enabled;
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                GetComponent<Animator>().enabled = false;
                SetEnabled(true);
            }
        }
    }
}