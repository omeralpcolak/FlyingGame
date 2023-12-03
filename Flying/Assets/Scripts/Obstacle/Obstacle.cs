using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleType obstacleType;

    public float movementSpeed;

    private void Start()
    {
        GetComponent<Renderer>().material.color = obstacleType.color;
        movementSpeed = obstacleType.movementSpeed;
        Debug.Log("Movement speed is: " + movementSpeed);
    }

    private void Update()
    {
        ObstacleMovement();
    }

    public void ObstacleMovement()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime * movementSpeed);
    }
}
