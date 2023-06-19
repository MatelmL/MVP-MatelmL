using UnityEngine;

public class DoorGrayBoxing : MonoBehaviour
{
    public bool isActive;
    private void OnTriggerEnter(Collider other)
    {
        Goblin goblin = other.gameObject.GetComponent<Goblin>();
        if (goblin != null && isActive)
        {
            goblin.ToggleState();
            goblin.gameObject.SetActive(false);
        }
    }
}
