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
    private GameOver gameOver;
    public bool playerOneWonRound;
    public bool playerTwoWonRound;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Explode", aliveLength);
        Invoke("EnableCollider", .2f);
        gameOver = FindObjectOfType<GameOver>();
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
                if (tankController.gameManager.playerOneHealth == 0 || tankController.gameManager.playerTwoHealth == 0)
                {
                    if (tankController.gameManager.playerOneHealth == 0)
                    {
                        GameData.playerTwoWins++;
                        GameData.playerTwoTotalWins++;
                        playerTwoWonRound = true;
                        playerOneWonRound = false;
                    }
                    else
                    {
                        GameData.playerOneWins++;
                        GameData.playerOneTotalWins++;
                        playerTwoWonRound = false;
                        playerOneWonRound = true;
                    }

                    gameOver.EndGame(playerTwoWonRound, playerOneWonRound, GameData.playerOneWins, GameData.playerTwoWins, tankController.gameManager.gamesToWin, tankController.gameManager);
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
