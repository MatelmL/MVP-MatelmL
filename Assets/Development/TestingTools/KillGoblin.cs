using Goblin;
using UnityEngine;

namespace  TestingTools
{
    public class KillGoblin : MonoBehaviour
    {
        public GameObject goblin;
        public void Kill()
        {
            if (goblin)
            {
                goblin.GetComponent<ITakeDamage>().TakeDamage(1000);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Kill();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                goblin.GetComponent<EnemyController>().OnSpawn();
            }
        }
    }
}
