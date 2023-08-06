using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RestartGameTimer : MonoBehaviour, IReset
{
    [SerializeField] int restartTime = 10;
    [SerializeField] float timeBeforeTimer = 10;
    [SerializeField] TextMeshProUGUI restartTimerText;
    private Vector3 scale;
    public void Reset()
    {
        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        AnimacionGameOver.OnAnimationCompleted += () => Invoke(nameof(Restart),timeBeforeTimer);
        scale = transform.localScale;
        Reset();
    }

    public void Restart()
    {
        transform.LeanScale(scale, 1f);
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
