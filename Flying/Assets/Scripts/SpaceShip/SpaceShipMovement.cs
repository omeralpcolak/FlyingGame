using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpaceShipMovement : MonoBehaviour
{
    Rigidbody spaceShipRb;

    public SpaceShipType spaceShipType;


    private void Awake()
    {
        spaceShipRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.DORotate(spaceShipType.rotationVector, spaceShipType.rotationTime, RotateMode.FastBeyond360)
            .SetLoops(-1)
            .SetRelative()
            .SetEase(Ease.Linear);
    }


    void FixedUpdate()
    {
        float acceleration = spaceShipType.accelerationAmount * Time.deltaTime;

        spaceShipRb.velocity += transform.forward * acceleration * spaceShipType.movementSpeed;
    }
}
