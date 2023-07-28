using Goblin;
using UnityEngine;
using UnityEngine.Events;
using System;
public class EnemyTweenAnimations : MonoBehaviour
{

    public Action onTweenEnd;
    public UnityEvent onTweenStart;
    public void InvokeDie(float time)
    {
        Invoke(nameof(Die), time);
    }
    private void Die()
    {
        transform.GetChild(1).LeanScale(Vector3.zero, 1f).setOnComplete(onTweenEnd).setOnStart(TweenStart);
    }
    private void TweenStart()
    {
        onTweenStart?.Invoke();
    }
}
