using UnityEngine;

public class AnimacionGameOver : MonoBehaviour, IReset
{
    public GameObject targetObject;
    public float scaleAndMoveDuration;
    public float startAnimacion;
    public Vector3 targetScale;
    private Vector3 originalScale;

    private void Start()
    {
        targetObject.SetActive(false);
        Door.OnDoorDieAction += GameOver;

        originalScale = targetObject.transform.localScale;
    }

    private void GameOver()
    {
        LeanTween.delayedCall(startAnimacion, () =>
        {
            targetObject.SetActive(true);

            LeanTween.scale(targetObject, targetScale, scaleAndMoveDuration)
                .setEase(LeanTweenType.easeOutSine);
        });
    }

    public void Reset()
    {
        targetObject.transform.localScale = originalScale;
        targetObject.SetActive(false);
    }
}