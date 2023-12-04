using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    public ObstacleType obstacleType;

    Rigidbody obstacleRb;

    private void Awake()
    {
        obstacleRb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material = obstacleType.obstacleMaterial;
    }

    private void Start()
    {
        transform.DOScale(obstacleType.obstacleScale, 1f);

        transform.DORotate(obstacleType.rotationVector, obstacleType.rotationTime, RotateMode.FastBeyond360)
            .SetLoops(-1)
            .SetRelative()
            .SetEase(Ease.Linear);
    }

    private void FixedUpdate()
    {
        ObstacleMovement();
        
    }

    public void ObstacleMovement()
    {
        //transform.Translate(-Vector3.forward * Time.deltaTime * movementSpeed);
        obstacleRb.MovePosition(obstacleRb.position + -Vector3.forward * Time.deltaTime * obstacleType.movementSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
