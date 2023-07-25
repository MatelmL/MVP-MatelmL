using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour, ITakeDamage
{
    public float health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    [SerializeField] ParticleSystem explotionVFX;
    [SerializeField] GameObject Barrel;


    [SerializeField] float explotionRadius;
    [SerializeField] float explotionForce;

    private void Awake()
    {
        explotionVFX.Stop();
    }

    public void TakeDamage(float damageAmount)
    {
        explotionVFX.Play();
        Barrel.SetActive(false);
    }

}
