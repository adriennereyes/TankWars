using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAiming : MonoBehaviour
{
    public int minPower = 0;
    public int maxPower = 100;
    public int currentPower;

    public int currentAngle;

    public SpriteRenderer arrowSprite;
    public TankController tankController;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject parentGameObj = transform.parent.gameObject.transform.parent.gameObject;
        tankController = parentGameObj.GetComponent<TankController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            CalculateAngle();
            CalculatePower();
        } else if (Input.GetMouseButtonUp(0)) {

        }
    }

    public void CalculateAngle() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - arrowSprite.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        UpdateAngle((int)angle);
    }

    public void UpdateAngle(int angle) {
        currentAngle = angle;

        // Check if the tank is facing left or right
        int direction = (tankController.isPlayerOne) ? 1 : -1;

        // Adjust the angle if necessary
        if (currentAngle < 0 && direction == 1) {
            currentAngle = 0;
        } else if (currentAngle > 180 && direction == -1) {
            currentAngle = 180;
        }

        // Set the rotation of the game object and arrow sprite
        transform.rotation = Quaternion.AngleAxis(currentAngle * direction, Vector3.forward);
        arrowSprite.transform.rotation = Quaternion.AngleAxis(currentAngle * direction, Vector3.forward);
    }

    public void CalculatePower() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        float distance = Vector3.Distance(mousePosition, transform.position);
        UpdatePower((int)distance * 2);
    }

    public void UpdatePower(int amount) {
        currentPower = Mathf.Clamp(amount, minPower, maxPower);
        arrowSprite.transform.localScale = new Vector2(currentPower / 2, 1);
    }
}
