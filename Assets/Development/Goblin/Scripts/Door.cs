using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Goblin goblin = other.gameObject.GetComponent<Goblin>();
        if (goblin != null)
        {
            goblin.ToggleState();
            goblin.gameObject.SetActive(false);
        }
    }
}
