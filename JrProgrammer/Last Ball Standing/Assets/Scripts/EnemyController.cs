using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.3f;
    private GameObject playerGO;
    private Rigidbody enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGO = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (playerGO.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y <= -2)
        {
            Destroy(gameObject);
        }
    }
}
