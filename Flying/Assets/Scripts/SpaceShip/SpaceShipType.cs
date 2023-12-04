using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Space Ship Type",menuName ="Space Ship Type")]
public class SpaceShipType : ScriptableObject
{
    public float movementSpeed;
    public float accelerationAmount;
    public float rotationTime;
    public Vector3 rotationVector;
}
