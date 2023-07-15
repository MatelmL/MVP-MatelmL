using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //singleton
    public static GameManager Instance;

    public Door door;

    public bool lose = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Door.OnDoorDie += () => lose = true;
    }

    public void RestartGame()
    {
        lose = false;
        RestartDoor();

        //startgoblng
    }

    private void RestartDoor()
    {
        door.gameObject.SetActive(true);
        door.ResetLife();
    }
}
