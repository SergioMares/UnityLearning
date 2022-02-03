using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    private GameObject Obstacle_To_Activate;
    private int Obstacles_Count, Obstacles_Range;

    // Start is called before the first frame update
    void Start()
    {
        Obstacles_Count = transform.childCount;
        Obstacles_Range = Random.Range(0, Obstacles_Count);

        Obstacle_To_Activate = gameObject.transform.GetChild(Obstacles_Range).gameObject;
        Obstacle_To_Activate.SetActive(true);

        Debug.Log(Obstacles_Range);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
