using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTweenAnimations : MonoBehaviour
{
    public void InvokeDie()
    {
        Invoke("Die", 2f);
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
