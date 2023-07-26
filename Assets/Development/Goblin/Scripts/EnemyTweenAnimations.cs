using Goblin;
using UnityEngine;
using System;
public class EnemyTweenAnimations : MonoBehaviour
{

    public Action onTweenEnd;
    public void InvokeDie(float time)
    {
        Invoke(nameof(Die), time);
    }
    private void Die()
    {
        transform.GetChild(1).LeanScale(Vector3.zero, 1f).setOnComplete(onTweenEnd);
    }
}
