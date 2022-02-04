using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float spawnDogDelay = 1,
                tempoTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (tempoTime <= 0)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                tempoTime = spawnDogDelay;
            }
        }
        else
            tempoTime -= Time.deltaTime;
    }
}
