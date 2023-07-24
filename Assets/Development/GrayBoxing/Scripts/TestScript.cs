using UnityEngine;

namespace GrayBoxing
{
    public class TestScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Goblin[] goblins = FindObjectsOfType<Goblin>();
                if (goblins.Length > 0) goblins[0].GoblinDie();

            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (Time.timeScale == 0) Time.timeScale = 1;
                else Time.timeScale = 0;
            }
        }
    }
}