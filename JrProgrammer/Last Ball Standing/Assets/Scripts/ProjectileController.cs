using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    float projectileStrength = 50,
          projectileSpeed = 10;  
    Rigidbody projectileRb;


    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody>();
        projectileRb.AddRelativeForce(Vector3.forward * projectileSpeed, ForceMode.Impulse);
        Invoke("autoDestroy", 2);
    }

    void autoDestroy()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromProjectile = collision.transform.position - transform.position;

            enemyRb.AddForce(awayFromProjectile * projectileStrength, ForceMode.Impulse);
        }
    }
}
