using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();


    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }


    IEnumerator SpawnObstacles()
    {
        int randomIndex = Random.Range(0, obstacles.Count);

        Vector3 randomPos = new Vector3 (Random.Range(-3f,3f), 1f, Random.Range(50f,80f));

        GameObject obstaclePrefab = obstacles[randomIndex];

        Instantiate(obstaclePrefab, randomPos, Quaternion.identity);

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(SpawnObstacles());
    }

    

}
