using UnityEngine;

public class ResetOnGameRestart : MonoBehaviour
{
    private IReset Reset;
    private void Awake()
    {
        Reset = GetComponent<IReset>();
        if (Reset == null) return;
        GameManager.OnGameRestart += Reset.Reset;

    }
    
    private void OnDestroy()
    {
        if (Reset == null) return;
        GameManager.OnGameRestart -= Reset.Reset;
    }
}
