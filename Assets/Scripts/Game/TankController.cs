using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Animator animator;
    private Rigidbody2D rigidbody2d;
    private Transform canonTransform; // Assign the cannon child object here in the Inspector
    public float rotationSpeed; // Adjust this to change the speed of rotation
    public bool isPlayerOne;
    public bool isPlayerTwo;
    public GameManager gameManager;
    public float maxDistance; // maximum allowed distance here
    public float totalDistance; // total distance traveled
    public float distanceLeft;
    public bool shotMissile;
    private GasBar gasbar;
    private GasBar2 gasbar2;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody2d = GetComponentInChildren<Rigidbody2D>();
        canonTransform = transform.Find("tankbody").transform.Find("tankcanon");
        rotationSpeed = 30f;
        maxDistance = 10f;
        totalDistance = 0f;
        shotMissile = false;
        gasbar = gameObject.GetComponent<GasBar>();
        gasbar2 = gameObject.GetComponent<GasBar2>();

        //after turns was implemented, checks tank is which player
        if (gameObject.name == "PlayerOneTank")
        {
            isPlayerOne = true;
        }
        else if (gameObject.name == "PlayerTwoTank")
        {
            isPlayerTwo = true;
        }
    }

    void Update()
    {
        if ((isPlayerOne && gameManager.gameState == GameManager.GameState.Player1Turn)
            || (isPlayerTwo && gameManager.gameState == GameManager.GameState.Player2Turn))
        {

            float horizontalInput = Input.GetAxisRaw("Horizontal");

            if (horizontalInput < 0)
            {
                animator.SetBool("isMoving", true);
                rigidbody2d.velocity = new Vector2(-moveSpeed, 0);
                totalDistance += Mathf.Abs(rigidbody2d.velocity.x) * Time.deltaTime; // Calculate distance traveled
            }
            else if (horizontalInput > 0)
            {
                animator.SetBool("isMoving", true);
                rigidbody2d.velocity = new Vector2(moveSpeed, 0);
                totalDistance += Mathf.Abs(rigidbody2d.velocity.x) * Time.deltaTime; // Calculate distance traveled
            }
            else
            {
                animator.SetBool("isMoving", false);
                rigidbody2d.velocity = Vector2.zero;
            }

            // Check if total distance traveled exceeds maximum allowed distance
            if (totalDistance > maxDistance)
            {
                // Stop the tank from moving further
                animator.SetBool("isMoving", false);
                rigidbody2d.velocity = Vector2.zero;
                totalDistance = maxDistance; // Set total distance to the maximum allowed distance
            }

            distanceLeft = maxDistance - totalDistance;
            
            if (gameObject.name == "PlayerOneTank")
            {
                
                Debug.Log("decreasing p1 gas");
                gasbar.UpdateGasbar(maxDistance, distanceLeft);
            }
            else if (gameObject.name == "PlayerTwoTank")
            {
                isPlayerTwo = true;
                gasbar2.UpdateGasbar(maxDistance, distanceLeft);
            }
        

        }
        else
        {
            // Tank is inactive, disable movement
            animator.SetBool("isMoving", false);
            rigidbody2d.velocity = Vector2.zero;
        }
    }
}
