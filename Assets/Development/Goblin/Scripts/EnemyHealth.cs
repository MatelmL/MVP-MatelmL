using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goblin
{
    public class EnemyHealth : MonoBehaviour, ITakeDamage
    {
        private EnemyState state;

        private void Awake()
        {
            state = GetComponent<EnemyState>();
        }

        public float health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void TakeDamage(float damageAmount)
        {
            state.StartDying();
        }
    }
}
