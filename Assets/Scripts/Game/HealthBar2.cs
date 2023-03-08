using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2 : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;

    public void UpdateHealthbar(float maxHealth, float currentHealth) {
        _healthbarSprite.fillAmount = currentHealth / maxHealth;
    }
}
