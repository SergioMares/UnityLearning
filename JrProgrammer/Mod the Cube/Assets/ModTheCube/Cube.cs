using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    Vector3 CubePosition = new Vector3(0, 0, 0);
    [SerializeField]
    Vector3 CubeScale = Vector3.one * 1.3f;
     
    public float angVelX = 0,
                 angVelY = 0,
                 angVelZ = 0;  

    Color color;
    Material material;
       
    float R = 0.5f, 
        G = 0.5f, 
        B = 0.5f, 
        A = 0.5f;

    bool bR = true,
         bG = true,
         bB = true,
         bA = true;

    [SerializeField]
    bool bRainbow = true;

    void Start()
    {
        transform.position = CubePosition;
        
        material = Renderer.material;

    }
    
    void Update()
    {
        transform.localScale = CubeScale;
        transform.Rotate(angVelX * Time.deltaTime, 
                         angVelY * Time.deltaTime, 
                         angVelZ * Time.deltaTime);
        if (bRainbow)
            ChangeColor();
        color = new Color(R, G, B, A);        
        
        material.color = color;
    }

    void ChangeColor()
    {
        int ch = Random.Range(0, 4);

        switch (ch)
        {
            case 0:
                if (R > 0.9)
                    bR = false;
                else if (R < 0.1)
                    bR = true;

                if (bR)
                    R += 0.01f;
                else
                    R -= 0.01f;

                break;

            case 1:
                if (G > 0.9)
                    bG = false;
                else if (G < 0.1)
                    bG = true;

                if (bG)
                    G += 0.01f;
                else
                    G -= 0.01f;
                break;

            case 2:
                if (B > 0.9)
                    bB = false;
                else if (B < 0.1)
                    bB = true;

                if (bB)
                    B += 0.01f;
                else
                    B -= 0.01f;
                break;

            case 3:
                if (A > 0.9)
                    bA = false;
                else if (A < 0.1)
                    bA = true;

                if (bA)
                    A += 0.01f;
                else
                    A -= 0.01f;
                break;

            default:
                break;
        }
    }
}
