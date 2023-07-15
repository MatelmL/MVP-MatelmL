using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTweenAnimations : MonoBehaviour
{
    public void InvokeDie(float time)
    {
        Invoke("Die", time);
    }
    private void Die()
    {

        transform.LeanScale(Vector3.zero, 1f)
            .setOnComplete(
            () => Debug.Log("Se Murio")
                //devolver al pool
            );
    }
}
