using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FloatingJoystick joystick;
    public int moveSpeed;
    public float maxRotationAngle;
    public float rotationSpeed;

    private Rigidbody playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        float horizontalMove = joystick.Horizontal;

        // Calculate the target rotation based on the horizontal movement
        float targetRotationAngle = Mathf.Lerp(0f, horizontalMove > 0 ? maxRotationAngle : -maxRotationAngle, Mathf.Abs(horizontalMove));

        // Smoothly interpolate between the current rotation and the target rotation
        Quaternion targetRotation = Quaternion.Euler(0f, targetRotationAngle, targetRotationAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

        // Move the player horizontally
        Vector3 moveVector = new Vector3(horizontalMove, 0f, 0f) * moveSpeed * Time.fixedDeltaTime;
        playerRb.MovePosition(playerRb.position + moveVector);
    }
}
