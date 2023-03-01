using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody2D rb;

    public float aliveLength = 3f;
    public float radius = 2f;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Explode", aliveLength);
        Invoke("EnableCollider", .2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(int power) {
        rb.AddForce(transform.right * (power), ForceMode2D.Impulse);
    }

    public void EnableCollider() {
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Explode();
    }

    public void Explode() {
        Destroy(gameObject);
    }
}
