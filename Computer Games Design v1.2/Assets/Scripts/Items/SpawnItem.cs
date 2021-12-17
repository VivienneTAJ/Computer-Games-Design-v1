using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{   
    public DungeonCreator dungeonCreator;
    public GameObject[] itemsToSpawn;
    public GameObject coinToSpawn;
    public GameObject playerToSpawn;
    private int randomItemIndex;
    public int numCoinsToSpawn, numItemsToSpawn;
    public float spawnRangeWidth, spawnRangeLength;
    public float rayLength = 10f;

    void Start()
    {
        spawnRangeWidth = dungeonCreator.dungeonWidth;
        spawnRangeLength = dungeonCreator.dungeonLength;
        SpawnPlayer();
        for (int i = 0; i < numCoinsToSpawn; i++)
        {
            SpawnCoins();            
        }
        for (int i = 0; i < numItemsToSpawn; i++)
        {
            PickItemToSpawn();
            SpawnItems();
        }
    }
    void SpawnCoins()
    {
        bool validSpawn = false;
        RaycastHit hit;
        while (!validSpawn)
        {
            Vector3 randPosition = new Vector3(Random.Range(0, spawnRangeWidth), 0f, Random.Range(0, spawnRangeLength)) + transform.position;
            if (validSpawn = Physics.Raycast(randPosition, Vector3.down, out hit, rayLength) && hit.collider.gameObject.tag == "Floor")
            {
                GameObject clone = Instantiate(coinToSpawn, randPosition, Quaternion.identity);
                clone.transform.parent = transform;
            }
        }
    }
    void SpawnItems()
    {
        bool validSpawn = false;
        RaycastHit hit;
        while (!validSpawn)
        {
            Vector3 randPosition = new Vector3(Random.Range(0, spawnRangeWidth), 0f, Random.Range(0, spawnRangeLength)) + transform.position;
            if (validSpawn = Physics.Raycast(randPosition, Vector3.down, out hit, rayLength) && hit.collider.gameObject.tag == "Floor")
            {
                GameObject clone = Instantiate(itemsToSpawn[randomItemIndex], randPosition, Quaternion.identity);
                clone.transform.parent = transform;
            }
        }
    }
    void SpawnPlayer()
    {
        bool validSpawn = false;
        RaycastHit hit;
        while (!validSpawn)
        {            
            Vector3 randPosition = new Vector3(Random.Range(0, spawnRangeWidth), -0.15f, Random.Range(0, spawnRangeLength)) + transform.position;
            if (validSpawn = Physics.Raycast(randPosition, Vector3.down, out hit, rayLength) && hit.collider.gameObject.tag == "Floor")
            {
                playerToSpawn.transform.position = randPosition;
            }
        }
    }
    void PickItemToSpawn()
    {
        randomItemIndex = Random.Range(0, itemsToSpawn.Length);
    }
}
