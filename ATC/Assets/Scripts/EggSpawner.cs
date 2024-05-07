using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> eggs; // List of egg prefabs
    [SerializeField] private float spawnRange = 10;
    [SerializeField] private float spawnInterval = 1; // [seconds]

    // Start is called before the first frame update
    void Start()
    {
        SpawnEggs();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEggs()
    {
        StartCoroutine(SpawnEggsRoutine());
    }

    IEnumerator SpawnEggsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEggRandom();
        }
    }

    void SpawnEggRandom()
    {
        // Choose a random egg from the list
        int randomIndex = Random.Range(0, eggs.Count);
        GameObject selectedEggPrefab = eggs[randomIndex];

        float randomX = Random.Range(-spawnRange, spawnRange);
        float spawnY = transform.position.y + spawnRange; // Spawn from the top
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

        // Instantiate the selected egg prefab
        GameObject newEgg = Instantiate(selectedEggPrefab, spawnPosition, Quaternion.identity);
        Destroy(newEgg, 10);
        newEgg.transform.eulerAngles = new Vector3(0, 0, 45);
    }
}
