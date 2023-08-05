using UnityEngine;
using TMPro;

public class WaveCountUI : MonoBehaviour,IReset
{
    public TextMeshProUGUI waveCountText;

    public void Reset()
    {
        waveCountText.text = 0 + "/" + 8;

    }

    private void Awake()
    {
        WaveManager.OnWaveClear += UpdateUI;
    }
    void UpdateUI(int wave, int nextRest)
    {
        waveCountText.text = wave + "/" + nextRest;
    }
}
