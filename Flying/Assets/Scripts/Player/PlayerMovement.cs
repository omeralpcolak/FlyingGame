using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FloatingJoystick joystick;

    public int moveSpeed;

    public float horizontalLimit;
    public float maxRotationAngle;
    public float rotationSpeed;

    private Rigidbody playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        float horizontalMove = joystick.Horizontal;

        float targetRotationAngle = Mathf.Lerp(0f, horizontalMove > 0 ? maxRotationAngle : -maxRotationAngle, Mathf.Abs(horizontalMove));

        Quaternion targetRotation = Quaternion.Euler(0f, targetRotationAngle, targetRotationAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

        Vector3 moveVector = new Vector3(horizontalMove, 0f, 0f) * moveSpeed * Time.fixedDeltaTime;


        playerRb.MovePosition(ClampPosition(playerRb.position + moveVector));
    }


    private Vector3 ClampPosition(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, -horizontalLimit, horizontalLimit);
        return position;
    }
}
