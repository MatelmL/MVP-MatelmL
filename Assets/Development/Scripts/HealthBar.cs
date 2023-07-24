using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;

    private Door health;

    void Start()
    {
        //health = health.GetComponent<Door>();
    }

    public void UpdateHealthBar(float health)
    {
        healthBar.fillAmount = health;
    }
}
