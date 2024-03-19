using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float spawnRange = 20;
    [SerializeField] private float spawnHeight = 20; // Adjust this to set the height from which coins spawn

    // Start is called before the first frame update
    void Start()
    {
        SpawnCoins();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnCoins()
    {
        StartCoroutine(SpawnCoinsRoutine());
    }

    IEnumerator SpawnCoinsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            SpawnCoinRandom();
        }
    }

    void SpawnCoinRandom()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);

        // Set the spawn position at a fixed height above the player
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0);

        GameObject newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        Destroy(newCoin, 5);
        newCoin.transform.eulerAngles = new Vector3(0, 0, 45);
    }
}
