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
        StartCoroutine(SpawnObject(obstacles, GenerateRandomPos(obstacleMinX, obstacleMaxX, obstacleMinY, obstacleMaxY, obstacleMinZ, obstacleMaxZ, "Obstacle"),obstacleSpawnCooldown));
        StartCoroutine(SpawnObject(spaceShips, GenerateRandomPos(spaceShipMinX, spaceShipMaxX, spaceShipMinY, spaceShipMaxY, spaceShipMinZ, spaceShipMaxZ,"SpaceShip"), spaceShipSpawnCooldown));
    }

    IEnumerator SpawnObject(List<GameObject> objectList,Vector3 randomPos,float cooldown)
    {
        while (true)
        {
            int randomIndex = Random.Range(0, objectList.Count);
            
            GameObject objectPrefab = objectList[randomIndex];

            Instantiate(objectPrefab, randomPos, Quaternion.identity);

            yield return new WaitForSeconds(cooldown);
        }
        
    }

    private Vector3 GenerateRandomPos(int minX, int maxX, int minY, int maxY, int minZ, int maxZ,string objectName)
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        if (objectName == "SpaceShip")
        {
            while (randomY >= -40f && randomY <= 40f)
            {
                randomY = Random.Range(minY, maxY);
            }
        }
        
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 randomPos = new Vector3(randomX, randomY, randomZ);
        return randomPos;
    }    

}
