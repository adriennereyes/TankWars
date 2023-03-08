using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public Vector2 direction = Vector2.right;
    public float strength = 1f;
    public float turbulence = 0.1f;

    void OnTriggerStay2D(Collider2D collider)
    {
        Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 windForce = direction.normalized * strength * (1f + turbulence * Random.Range(-1f, 1f));
            rb.AddForce(windForce, ForceMode2D.Force);
        }
    }
}
