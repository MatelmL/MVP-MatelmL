using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundsManager : MonoBehaviour
{
   [SerializeField] AudioSource startMusic, combatMusic, Shofar;
    [SerializeField] float timeChange, valueChange;

    public static SoundsManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void StartMusic()
    {
        StartCoroutine(ChangeMusic());
    }

     IEnumerator ChangeMusic()
     {
        combatMusic.Play();
        yield return new WaitForSeconds(timeChange);
        combatMusic.volume += valueChange;
        startMusic.volume = 1 - combatMusic.volume;
        if (combatMusic.volume >= 1) startMusic.Stop();
        else StartCoroutine(ChangeMusic());
     }
    public void PlayShofar()
    {
        Shofar.Play();
    }

}
