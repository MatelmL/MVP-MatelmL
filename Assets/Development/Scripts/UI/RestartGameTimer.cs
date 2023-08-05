using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RestartGameTimer : MonoBehaviour, IReset
{
    [SerializeField] int restartTime = 10;
    [SerializeField] float timeBeforeTimer = 10;
    [SerializeField] TextMeshProUGUI restartTimerText;
    public void Reset()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        AnimacionGameOver.OnAnimationCompleted += () => Invoke(nameof(Restart),timeBeforeTimer);
        Reset();
    }

    public void Restart()
    {
        gameObject.SetActive(true);
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {

        for (int i = restartTime; i > 0; i--)
        {
            restartTimerText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        GameManager.Instance.RestartGame();
    }
}
