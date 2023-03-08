using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody2D rb;

    public float aliveLength = 8f;
    public float radius = 2f;
    public GameObject explosionPrefab;
    public AudioClip explosionClip;
    private AudioSource explosionAudioSource;

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

    public void Initialize(int power)
    {
        rb.AddForce(transform.right * (power), ForceMode2D.Impulse);
    }

    public void EnableCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Wind")
        {
            Explode();
            if (collision.gameObject.name == "tankbody")
            {
                TankController tankController = collision.gameObject.transform.parent.gameObject.GetComponent<TankController>();
                if (tankController.isPlayerOne)
                {
                    tankController.gameManager.playerOneHealth -= 1;
                }
                else
                {
                    tankController.gameManager.playerTwoHealth -= 1;
                }
            }
        }
    }

    public void Explode()
    {
        Destroy(gameObject);
        SpawnExplosionFX();
    }

    public void SpawnExplosionFX()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosionAudioSource = explosion.AddComponent<AudioSource>();
        explosionAudioSource.volume = 0.6f;
        explosionAudioSource.PlayOneShot(explosionClip);
        explosion.transform.localScale *= radius;
        explosion.GetComponent<Animator>().SetBool("isExplosion", true);
        Destroy(explosion, .5f);
    }
}
