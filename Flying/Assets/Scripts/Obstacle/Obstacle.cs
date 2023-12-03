using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    public ObstacleType obstacleType;

    private float movementSpeed;

    private void Start()
    {
        GetComponent<Renderer>().material = obstacleType.obstacleMaterial;
        movementSpeed = obstacleType.movementSpeed;

        transform.DOScale(obstacleType.obstacleScale, 1f);
    }

    private void FixedUpdate()
    {
        ObstacleMovement();
        
    }

    public void ObstacleMovement()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime * movementSpeed);
    }
}
