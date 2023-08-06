using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] List<AudioSource>  musics = new List<AudioSource>();
    [SerializeField] AudioSource  Shofar;
    [SerializeField] float timeChange, valueChange;

    [SerializeField] AudioSource actualSourse;

    public static SoundsManager instance;
    private void Awake()
    {
        instance = this;
        Door.OnDoorDieAction += DieSound;
    }
    void DieSound()
    {
        ChangeMusic("Source EndGame");
    }
    public void ChangeMusic(string newMusic)
    {
        StopAllCoroutines();
        foreach(AudioSource source in musics)
        {
            if(source != actualSourse) source.volume = 0;
            else source.volume = 1;
        }
        AudioSource newSourse = musics.Find(c => c.name == newMusic);
        if (newSourse == actualSourse) return;
        newSourse.Play();
        StartCoroutine(ChangeMusicCoroutine(newSourse));
    }

     IEnumerator ChangeMusicCoroutine(AudioSource newMusic)
    {
        
        yield return new WaitForSeconds(timeChange);
        newMusic.volume += valueChange;
        actualSourse.volume = 1 - newMusic.volume;
        if (newMusic.volume >= 1)
        {
            actualSourse.Stop();
            actualSourse = newMusic;
        }
        else StartCoroutine(ChangeMusicCoroutine(newMusic));
     }
    public void PlayShofar()
    {
        Shofar.Play();
    }

}
