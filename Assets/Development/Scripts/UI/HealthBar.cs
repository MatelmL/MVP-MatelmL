using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IReset
{
    public Image healthBar;

    public void Reset()
    {
        healthBar.fillAmount = 1;
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
