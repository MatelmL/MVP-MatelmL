using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] randomClips;
    [SerializeField] List<AudioClip> clips;

    public void PlayClip(string clip)
    {
        AudioClip audioClip = clips.Find(c => c.name == clip);
        if (audioClip == null) return;
        source.PlayOneShot(audioClip);
    }

    public void PlayClip(AudioClip clip)
    {
        if (clip == null) return;
        source.clip = clip;
        source.Play();
    }
    public void RandomSound() 
    {
        int randomSound = Random.Range(0, randomClips.Length);
        source.clip = randomClips[randomSound];
        source.Play();
    }
}
