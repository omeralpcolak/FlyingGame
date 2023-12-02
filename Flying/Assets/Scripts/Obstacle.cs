using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    
    void FixedUpdate()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime * 20f);
    }
}
