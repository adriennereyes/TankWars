using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private HealthBar healthbar;
    private HealthBar2 healthbar2;
    public enum GameState
    {
        Player1Turn,
        Player2Turn,
        GameOver
    }

    public GameState gameState;
    public GameObject playerOneTank;
    public GameObject playerTwoTank;
    public TankController tankController1;
    public TankController tankController2;
    public TankShooting tankShooting1;
    public TankShooting tankShooting2;
    public TankAiming tankAiming1;
    public TankAiming tankAiming2;
    public int playerOneHealth;
    public int playerTwoHealth;
    public Wind wind1;
    public Wind wind2;
    public Wind noWind;
    public Wiggle wiggleScript;
    public float timeBetweenWinds = 30f;
    private float timeSinceWind = 0f;
    private int windCount = 0;

    void Start()
    {
        gameState = GameState.Player1Turn;
        EnableTankControls(tankController1, tankAiming1, tankShooting1);
        DisableTankControls(tankController2, tankAiming2, tankShooting2);
        playerOneHealth = 3;
        playerTwoHealth = 3;
        wind1.gameObject.SetActive(false);
        wind2.gameObject.SetActive(false);
        noWind.gameObject.SetActive(true);
        healthbar = gameObject.GetComponent<HealthBar>();
        healthbar2 = gameObject.GetComponent<HealthBar2>();
    }

    void Update()
    {
        healthbar.UpdateHealthbar(3, playerOneHealth);
        healthbar2.UpdateHealthbar(3, playerTwoHealth);

        if (tankController1.shotMissile || tankController2.shotMissile) {
            GameObject[] missiles = GameObject.FindGameObjectsWithTag("Missile");
            GameObject[] explosions = GameObject.FindGameObjectsWithTag("Explosion");
            if ((missiles.Length == 0) && (explosions.Length == 0) ) {
                EndTurn();
            }
        }
        timeSinceWind += Time.deltaTime;
        if (timeSinceWind >= timeBetweenWinds)
        {
            ActivateWind();
        }
    }

    void ActivateWind()
    {
        windCount++;
        if (windCount % 3 == 0)
        {
            wiggleScript.stopWiggle();
            wind1.gameObject.SetActive(false);
            wind2.gameObject.SetActive(false);
            noWind.gameObject.SetActive(true);
        }
        else if (windCount % 2 == 0)
        {
            wiggleScript.startWiggle();
            wind1.gameObject.SetActive(false);
            wind2.gameObject.SetActive(true);
            noWind.gameObject.SetActive(false);
        }
        else
        {
            wiggleScript.startWiggle();
            wind1.gameObject.SetActive(true);
            wind2.gameObject.SetActive(false);
            noWind.gameObject.SetActive(false);
        }
        timeSinceWind = 0f;
    }

    public void EndTurn()
    {
        GameObject tankArrow1 = playerOneTank.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        GameObject tankArrow2 = playerTwoTank.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        if (gameState == GameState.Player1Turn)
        {
            gameState = GameState.Player2Turn;
            tankController1.totalDistance = 0f;
            tankController1.shotMissile = false;
            tankArrow1.SetActive(false);
            tankArrow2.SetActive(true);
            tankController2.enabled = true;
            tankShooting2.enabled = true;
            tankAiming2.enabled = true;
            ActivateWind();
        }
        else if (gameState == GameState.Player2Turn)
        {
            gameState = GameState.Player1Turn;
            tankController2.totalDistance = 0f;
            tankController2.shotMissile = false;
            tankArrow2.SetActive(false);
            tankArrow1.SetActive(true);
            tankController1.enabled = true;
            tankShooting1.enabled = true;
            tankAiming1.enabled = true;
            ActivateWind();
        }
    }

    void EnableTankControls(TankController controller, TankAiming aiming, TankShooting shooting)
    {
        controller.enabled = true;
        aiming.enabled = true;
        shooting.enabled = true;
    }

    void DisableTankControls(TankController controller, TankAiming aiming, TankShooting shooting)
    {
        controller.enabled = false;
        aiming.enabled = false;
        shooting.enabled = false;
    }
}
