using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar : MonoBehaviour
{
    [SerializeField] private Image _gasbarSprite;

    public void UpdateGasbar(float maxGas, float currentGas)
    {
        _gasbarSprite.fillAmount = currentGas / maxGas;
    }
}
