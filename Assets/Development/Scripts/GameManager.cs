using UnityEngine;

public class GameManager : MonoBehaviour
{
    //singleton
    public static GameManager Instance;

    public Door door;

    public bool lose = false;

    [SerializeField] StartGobling startGobling;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Door.OnDoorDie += () => lose = true;
        RestartGame();
    }

    public void RestartGame()
    {
        lose = false;
        RestartDoor();
        StartGobling();
    }

    public void StartGobling()
    {
        startGobling.gameObject.SetActive(true);
        startGobling.Init();
    }

    private void RestartDoor()
    {
        door.gameObject.SetActive(true);
        door.ResetLife();
    }
}
