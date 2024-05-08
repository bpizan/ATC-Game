using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteroriteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnRange = 10;
    [SerializeField] private float spawnHeight = 40;
    [SerializeField] private float spawnInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartSpawning()
    {
        StartCoroutine(SpawnObjectsRoutine());
    }

    IEnumerator SpawnObjectsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnObjectRandom();
        }
    }

    void SpawnObjectRandom()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0);

        // Randomly choose between spawning a coin or an obstacle
        float spawnChance = Random.value;
        GameObject newObject;
        newObject = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        Destroy(newObject, 5); // Adjust the time for destruction as needed
    }
}
