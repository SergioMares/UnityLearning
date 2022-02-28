using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int value;
    public ParticleSystem explosionParticle;

    private Rigidbody targetRb;    
    private float torqueForceRange = 2,
                  forceUpMin = 8,
                  forceUpMax = 14,
                  posRangeX = 4,
                  posSpawnY = -1;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(Vector3.up * Random.Range(forceUpMin, forceUpMax), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-torqueForceRange, torqueForceRange), 
                           Random.Range(-torqueForceRange, torqueForceRange), 
                           Random.Range(-torqueForceRange, torqueForceRange), 
                           ForceMode.Impulse);

        transform.position = new Vector3(Random.Range(-posRangeX, posRangeX), posSpawnY);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {                
        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive)       
            gameManager.UpdateLives(-1);
        
        Destroy(gameObject);
    }

    private void OnMouseOver()
    {
        if (gameManager.isGameActive && gameManager.mouseState)
        {
            gameManager.UpdateScore(value);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
