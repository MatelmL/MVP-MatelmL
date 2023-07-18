using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goblin
{
    public class Ragdoll : MonoBehaviour
    {
        private Rigidbody[] rigidbodies;

        private void Awake()
        {
            rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
            SetEnabled(false);

        }



        public void SetEnabled(bool enabled)
        {
            bool isKinematic = !enabled;
            foreach (Rigidbody rigidbody in rigidbodies)
            {
                rigidbody.isKinematic = isKinematic;
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