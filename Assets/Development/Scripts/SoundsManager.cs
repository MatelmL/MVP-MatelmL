using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] List<AudioSource>  musics = new List<AudioSource>();
   [SerializeField] AudioSource  Shofar;
    [SerializeField] float timeChange, valueChange;

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
        AudioSource actualSourse = null;
        foreach (AudioSource music in musics)    
            if (music.volume >= 1)
            {
                actualSourse = music;
                break;
            }
        AudioSource newSourse = musics.Find(c => c.name == newMusic);
        if (newSourse == actualSourse) return;
        newSourse.Play();
        StartCoroutine(ChangeMusicCoroutine(actualSourse, newSourse));
    }

     IEnumerator ChangeMusicCoroutine(AudioSource actualSourse, AudioSource newMusic)
    {
        
        yield return new WaitForSeconds(timeChange);
        newMusic.volume += valueChange;
        actualSourse.volume = 1 - newMusic.volume;
        if (newMusic.volume >= 1) actualSourse.Stop();
        else StartCoroutine(ChangeMusicCoroutine(actualSourse, newMusic));
     }
    public void PlayShofar()
    {
        Shofar.Play();
    }

}
