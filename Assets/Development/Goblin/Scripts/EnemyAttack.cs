using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goblin {
    public class EnemyAttack : MonoBehaviour
    {
        public float damage = 10f;

        Door door;
        private void Start()
        {
            door = Paths.Instance.DoorPosition.gameObject.GetComponent<Door>();
        }

        //llamar desde la animacion
        public void MakeDamage()
        {
            door.TakeDamage(damage);
        }
    } 
}
