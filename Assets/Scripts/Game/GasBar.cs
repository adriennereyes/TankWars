using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar : MonoBehaviour
{
    [SerializeField] private Image gasbarSprite;

    public void UpdateGasbar(float maxGas, float currentGas)
    {
        Debug.Log("decreasing p1 gas");
        gasbarSprite.fillAmount = currentGas / maxGas;
    }
}
