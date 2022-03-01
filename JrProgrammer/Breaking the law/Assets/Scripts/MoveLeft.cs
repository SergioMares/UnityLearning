using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed,
                  leftBound = -15;
    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            //go double speed if true
            if (playerControllerScript.speedUp)
                transform.Translate(Vector3.left * Time.deltaTime * speed * 2, Space.World);
            else
                transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))        
            Destroy(gameObject);
        speed = playerControllerScript.speed;
    }
}
