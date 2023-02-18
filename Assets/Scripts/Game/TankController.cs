using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of the tank's movement
    private Transform canonTransform; // Assign the cannon child object here in the Inspector
    public float rotationSpeed; // Adjust this to change the speed of rotation

    // Start is called before the first frame update
    void Start()
    {
        canonTransform = transform.Find("canon");
        rotationSpeed = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input from the player
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;

        // Move the tank's body and gun using the movement vector
        transform.Translate(movement);

        // Get the current rotation of the cannon
        Quaternion currentRotation = canonTransform.localRotation;

        // Rotate the cannon when the up or down arrow key is pressed
        if (Input.GetKey(KeyCode.UpArrow)) {
            // Rotate the cannon towards -180 degrees
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, 180f);
            canonTransform.localRotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            // Rotate the cannon towards 0 degrees
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);
            canonTransform.localRotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
