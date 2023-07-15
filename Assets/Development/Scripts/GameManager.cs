using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //singleton
    public static GameManager Instance;

    public bool lose = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

}
