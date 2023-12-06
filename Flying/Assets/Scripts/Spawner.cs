using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();
    public int obstacleMinX, obstacleMaxX, obstacleMinY, obstacleMaxY, obstacleMinZ, obstacleMaxZ;
    public float obstacleSpawnCooldown;


    public List<GameObject> spaceShips = new List<GameObject>();
    public int spaceShipMinX, spaceShipMaxX, spaceShipMinY, spaceShipMaxY, spaceShipMinZ, spaceShipMaxZ;
    public float spaceShipSpawnCooldown;

    private void Start()
    {
        StartCoroutine(SpawnObject(obstacles,obstacleSpawnCooldown,"Obstacle"));
        StartCoroutine(SpawnObject(spaceShips, spaceShipSpawnCooldown,"SpaceShip"));
    }

    IEnumerator SpawnObject(List<GameObject> objectList,float cooldown,string objectName)
    {
        while (true)
        {
            int randomIndex = Random.Range(0, objectList.Count);
            
            GameObject objectPrefab = objectList[randomIndex];

            Vector3 randomPos = GenerateRandomPos(objectName);

            Instantiate(objectPrefab, randomPos, Quaternion.identity);

            yield return new WaitForSeconds(cooldown);
        }
        
    }

    private Vector3 GenerateRandomPos(string objectName)
    {
        float randomX = Random.Range(objectName == "SpaceShip" ? spaceShipMinX : obstacleMinX, objectName == "SpaceShip" ? spaceShipMaxX : obstacleMaxX);
        float randomY = Random.Range(objectName == "SpaceShip" ? spaceShipMinY : obstacleMinY, objectName == "SpaceShip" ? spaceShipMaxY : obstacleMaxY);

        if (objectName == "SpaceShip")
        {
            while (randomY >= -40f && randomY <= 40f)
            {
                randomY = Random.Range(spaceShipMinY, spaceShipMaxY);
            }
        }

        float randomZ = Random.Range(objectName == "SpaceShip" ? spaceShipMinZ : obstacleMinZ, objectName == "SpaceShip" ? spaceShipMaxZ : obstacleMaxZ);

        Vector3 randomPos = new Vector3(randomX, randomY, randomZ);
        return randomPos;
    }


}
