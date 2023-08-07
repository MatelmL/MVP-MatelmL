using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //singleton
    public static GameManager Instance;

    public bool lose = false;

    public static Action OnGameRestart;
    [SerializeField]public StartGobling startGobling;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Door.OnDoorDieAction += () => lose = true;
        RestartGame();
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
        lose = false;
        OnGameRestart?.Invoke();
    }

    public void StartGobling()
    {
        startGobling.Reset();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) { RestartGame(); }
    }
}
