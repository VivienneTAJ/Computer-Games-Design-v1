using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{   
    public DungeonCreator dungeonCreator;
    public GameObject[] itemsToSpawn;
    public GameObject coinToSpawn;
    private int randomItemIndex;
    public int numCoinsToSpawn, numItemsToSpawn;
    private float spawnRangeWidth, spawnRangeLength;
    public float rayLength = 10f;

    void Start()
    {
        spawnRangeWidth = dungeonCreator.dungeonWidth;
        spawnRangeLength = dungeonCreator.dungeonLength;

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
        RaycastHit hit;
        Vector3 randPosition = new Vector3(Random.Range(0, spawnRangeWidth), 0f, Random.Range(0, spawnRangeLength)) + transform.position;
        if (Physics.Raycast(randPosition, Vector3.down, out hit, rayLength))
        {
            if (hit.collider.gameObject.tag == "Floor")
            {
                GameObject clone = Instantiate(coinToSpawn, randPosition, Quaternion.identity);
                clone.transform.parent = transform;
            }

        }
    }
    void SpawnItems()
    {
        RaycastHit hit;
        Vector3 randPosition = new Vector3(Random.Range(0, spawnRangeWidth), 0f, Random.Range(0, spawnRangeLength)) + transform.position;
        if (Physics.Raycast(randPosition, Vector3.down, out hit, rayLength))
        {
            if (hit.collider.gameObject.tag == "Floor")
            {
                GameObject clone = Instantiate(itemsToSpawn[randomItemIndex], randPosition, Quaternion.identity);
                clone.transform.parent = transform;
            }
        }
    }
    void PickItemToSpawn()
    {
        randomItemIndex = Random.Range(0, itemsToSpawn.Length);
    }
}
