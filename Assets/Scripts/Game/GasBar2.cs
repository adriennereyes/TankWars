using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar2 : MonoBehaviour
{
    [SerializeField] private Image gasbarSprite;

    public void UpdateGasbar(float maxGas, float currentGas)
    {
        Debug.Log("decreasing p2 gas");
        gasbarSprite.fillAmount = currentGas / maxGas;
    }
}
