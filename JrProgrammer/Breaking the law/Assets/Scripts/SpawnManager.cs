using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    private float startDelay = 1,
                  spawnRate = 1.5f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, spawnRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        int index = Random.Range(0, obstaclePrefab.Length);

        if (playerControllerScript.gameOver == false)        
            Instantiate(obstaclePrefab[index], spawnPos, obstaclePrefab[index].transform.rotation);
    }
}
