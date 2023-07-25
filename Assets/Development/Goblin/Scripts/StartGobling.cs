using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartGobling : MonoBehaviour, ITakeDamage, IAddForce
{

    public UnityEvent OnStartGoblingDie;
    public UnityEvent OnStartGoblingEnable;
    public float health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public Rigidbody chestRb;
    public void TakeDamage(float damageAmount)
    {
        OnStartGoblingDie?.Invoke();
    }
    public void AddForce(float magnitude, Transform origin, float radius)
    {
        chestRb.AddForce(((transform.position - origin.position).normalized + Vector3.up) * magnitude, ForceMode.Impulse);
    }

    public void InvokeDie(float time)
    {
        Invoke("Die", time);
    }
    private void Die()
    {
        //GetComponent<Ragdoll>().SetEnabled(false);
        transform.GetChild(1).LeanScale(Vector3.zero, 1f).setOnComplete(Disable);
    }
    private void Disable()
    {
        WaveManager.Instance.StartWave();
        gameObject.SetActive(false);
    }
    public void Init()
    {
        OnStartGoblingEnable?.Invoke();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(0);
        }
    }
}
