using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goblin
{
    public class Ragdoll : MonoBehaviour
    {
        private Rigidbody[] rigidbodies;

        void Start()
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
    }
}