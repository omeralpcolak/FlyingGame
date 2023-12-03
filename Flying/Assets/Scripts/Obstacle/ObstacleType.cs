using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Obstacle Type", menuName = "Obstacle Type")]
public class ObstacleType : ScriptableObject
{
    public float movementSpeed;
    public float rotationTime;

    public string obstacleName;

    public Material obstacleMaterial;

    public Vector3 obstacleScale;
    public Vector3 rotationVector;
    
}
