using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 10,
                spawnRangeZ = 15,
                spawnPosZ = 20,
                startDelay = 2,
                spawnRate = 1.5f;

    public bool sideSpawn;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        if (sideSpawn)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(transform.position.x, 0, Random.Range(0,spawnRangeZ));

            Instantiate(animalPrefabs[animalIndex], spawnPos, transform.rotation);
        }
        else
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

            Instantiate(animalPrefabs[animalIndex], spawnPos, transform.rotation);
        }
    }
}
