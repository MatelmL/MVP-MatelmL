using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCountUI : MonoBehaviour
{
    public TextMeshProUGUI waveCountText;
    private void Awake()
    {
        WaveManager.OnWaveClear += UpdateUI;
    }
    void UpdateUI(int wave, int nextRest)
    {
        waveCountText.text = wave + "/" + nextRest;
    }
}
