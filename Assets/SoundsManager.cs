using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundsManager : MonoBehaviour
{
   [SerializeField] AudioSource startMusic, combatMusic;
    [SerializeField] float timeChange, valueChange;

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
}
