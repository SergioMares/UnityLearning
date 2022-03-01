using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{    
    PlayerStats ps;

    public int animalLife,
               points;
    
    Slider lifeSlider;

    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        lifeSlider = GetComponentInChildren<Slider>();
        points = animalLife * 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //just add points when hit with food 
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
            animalLife--;
            lifeSlider.value++;
        }
        else
            ps.UpdateLives(-1);
                
        if (animalLife <= 0)
        {
            ps.UpdateScore(points);
            Destroy(gameObject);
        }
    }
}
