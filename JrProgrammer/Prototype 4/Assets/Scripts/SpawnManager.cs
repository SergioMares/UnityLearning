using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab,
                      enemyHardPrefab,
                      enemyBossPrefab,
                      powerupPrefab,
                      powerupProjectilePrefab,
                      powerupSmash;
    public int enemyCounter;     

    private float spawnRange = 9.0f;
    private int waveNumber = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawnWave(waveNumber, enemyPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCounter = FindObjectsOfType<EnemyController>().Length;

        if (enemyCounter <= 0)
        {
            waveNumber++;
            Instantiate(powerupPrefab, GenerateRandomPos(), powerupPrefab.transform.rotation);
            EnemySpawnWave(waveNumber, enemyPrefab);

            if (waveNumber % 2 == 0)
            {
                EnemySpawnWave(waveNumber / 2, enemyHardPrefab);
                Instantiate(powerupSmash, GenerateRandomPos(), powerupProjectilePrefab.transform.rotation);
            }

            if (waveNumber % 3 == 0)
                Instantiate(powerupProjectilePrefab, GenerateRandomPos(), powerupProjectilePrefab.transform.rotation);

            if (waveNumber % 4 == 0)
                EnemySpawnWave(waveNumber / 4, enemyBossPrefab);
        }

    }

    private void EnemySpawnWave(int enemiesToSpawn, GameObject enemyType)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyType, GenerateRandomPos(), enemyPrefab.transform.rotation);            
        }
    }

    private Vector3 GenerateRandomPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
