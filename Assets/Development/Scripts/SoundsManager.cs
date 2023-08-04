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
        Door.OnDoorDie += DieSound;
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
        StartCoroutine(ChangeMusicCoroutine(actualSourse, newMusic));
    }

     IEnumerator ChangeMusicCoroutine(AudioSource actualSourse, string newMusic)
    {
        AudioSource newSourse = musics.Find(c => c.name == newMusic);
        newSourse.Play();
        yield return new WaitForSeconds(timeChange);
        newSourse.volume += valueChange;
        actualSourse.volume = 1 - newSourse.volume;
        if (newSourse.volume >= 1) actualSourse.Stop();
        else StartCoroutine(ChangeMusicCoroutine(actualSourse, newMusic));
     }
    public void PlayShofar()
    {
        Shofar.Play();
    }

}
