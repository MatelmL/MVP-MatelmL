using Goblin;
using UnityEngine;

public class EnemyTweenAnimations : MonoBehaviour
{
    public void InvokeDie(float time)
    {
        Invoke("Die", time);
    }
    private void Die()
    {
        //GetComponent<Ragdoll>().SetEnabled(false);
        transform.GetChild(1).LeanScale(Vector3.zero, 1f).setOnComplete(ReturnEnemy);
    }

    private void ReturnEnemy()
    {
        EnemyPool.Instance.ReturnEnemy(gameObject);
        WaveManager.Instance.EnemieDie();
    }
}
