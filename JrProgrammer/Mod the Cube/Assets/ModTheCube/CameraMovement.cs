using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float horizontalInput,
                 verticalInput,
                 speed = 100;
    public Transform pivX, pivY;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        pivX.Rotate(Vector3.down, speed * Time.deltaTime * horizontalInput);

        verticalInput = Input.GetAxis("Vertical");
        pivY.Rotate(Vector3.right, speed * Time.deltaTime * verticalInput);
    }
}
