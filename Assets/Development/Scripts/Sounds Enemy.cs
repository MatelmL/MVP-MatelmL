using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEnemy : MonoBehaviour
{
    [SerializeField]AudioSource source;
    [SerializeField] AudioClip[] randomClips;
    [SerializeField] AudioClip atacck, dead, deflated;

    public void AttackSound()
    {
        source.clip = atacck;
        source.Play();
    }
    public void DeadSound() 
    {
        source.clip = dead;
        source.Play();
    }
    public void DeflatedSound()
    {
        source.clip = deflated;
        source.Play();
    }
    public void RandomSound() 
    {
        int randomSound = Random.Range(0, randomClips.Length);
        source.clip = randomClips[randomSound];
        source.Play();
    }
}
