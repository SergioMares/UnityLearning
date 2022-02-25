using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool hasPowerup = false;
    public GameObject powerupIndicator,
                      projectiles;    

    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrength = 15;
    private EnemyController[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");        
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
        if (other.CompareTag("PowerupP"))
        {            
            Instantiate(projectiles, transform.position, projectiles.transform.rotation);            
            Destroy(other.gameObject);
        }
        if (other.CompareTag("PowerupS"))
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            Invoke("Smash", 0.5f);
            Destroy(other.gameObject);
        }
    }

    void Smash()
    {
        playerRb.AddForce(Vector3.down * 10, ForceMode.Impulse);
        enemies = GameObject.FindObjectsOfType<EnemyController>();
        for (int i = 0; i < enemies.Length; i++)
        {
            Vector3 distance = enemies[i].transform.position - transform.position;
            Rigidbody enemyRb = enemies[i].GetComponent<Rigidbody>();
            enemyRb.AddForce(distance * powerupStrength, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("EnemyB"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromEnemy = transform.position - collision.transform.position;

            enemyRb.AddForce(awayFromEnemy * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);

    }
}
