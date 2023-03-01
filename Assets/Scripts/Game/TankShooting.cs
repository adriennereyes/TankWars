using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject misslePrefab;

    public void FireMissile(int power, int currentAngle) {
        GameObject insMissile = Instantiate(misslePrefab, transform.position, Quaternion.Euler(0, 0, Mathf.Abs(currentAngle)));
        insMissile.GetComponent<Missile>().Initialize(power);
    }
}
