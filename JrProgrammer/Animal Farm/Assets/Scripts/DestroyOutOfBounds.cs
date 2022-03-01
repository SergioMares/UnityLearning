using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30,
                  lowerBound = -10,
                  sideBound = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
            Destroy(gameObject);
        else if (transform.position.z < lowerBound)        
            Destroy(gameObject);


        if (transform.position.x > sideBound)
            Destroy(gameObject);
        else if (transform.position.x < -sideBound)
            Destroy(gameObject);
    }
}
