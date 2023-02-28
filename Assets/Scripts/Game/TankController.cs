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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody2d = GetComponentInChildren<Rigidbody2D>();
        canonTransform = transform.Find("tankbody").transform.Find("tankcanon");
        rotationSpeed = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0) {
            animator.SetBool("isMoving", true);
            rigidbody2d.velocity = new Vector2(-moveSpeed, 0);
        } else if (horizontalInput > 0) {
            animator.SetBool("isMoving", true);
            rigidbody2d.velocity = new Vector2(moveSpeed, 0);
        } else {
            animator.SetBool("isMoving", false);
            rigidbody2d.velocity = Vector2.zero;
        }

        // // Get the current rotation of the cannon
        // Quaternion currentRotation = canonTransform.localRotation;

        // // Rotate the cannon when the up or down arrow key is pressed
        // if (Input.GetKey(KeyCode.UpArrow)) {
        //     // Rotate the cannon towards -180 degrees
        //     float angleMax;
        //     if (isPlayerOne) {
        //         angleMax = -180f;
        //     } else {
        //         angleMax = 180f;
        //     }
        //     Quaternion targetRotation = Quaternion.Euler(0f, 0f, angleMax);
        //     canonTransform.localRotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        // } else if (Input.GetKey(KeyCode.DownArrow)) {
        //     // Rotate the cannon towards 0 degrees
        //     Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);
        //     canonTransform.localRotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        // }
    }
}
