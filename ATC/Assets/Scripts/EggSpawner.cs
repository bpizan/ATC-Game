using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] private GameObject eggPrefab;
    [SerializeField] private float spawnRange = 10;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEggs();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEggs(){
        StartCoroutine(SpawnEggsRoutine());
        IEnumerator SpawnEggsRoutine(){
            while(true){
                yield return new WaitForSeconds(1);
                SpawnEggRandom();
            }
        }
    }




    void SpawnEggRandom(){

       float randomX = Random.Range(-spawnRange,spawnRange);
       float randomY = Random.Range(-spawnRange,spawnRange);

       GameObject newEgg = Instantiate(eggPrefab,new Vector3(randomX,randomY,0),Quaternion.identity);
       Destroy(newEgg,10);
       newEgg.transform.eulerAngles = new Vector3(0,0,45);
    }
}
