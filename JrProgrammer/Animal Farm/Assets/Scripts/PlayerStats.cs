using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int score = 0, 
               lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lives: " + lives + "\nScore: " + score);
    }

    public void UpdateScore(int modScore)
    {
        score += modScore;
        Debug.Log("Score: " + score);
    }

    public void UpdateLives(int modLives)
    {
        lives += modLives;
        if (lives <= 0)
        {
            Debug.Log("Game Over!");            
            Destroy(gameObject);
            foreach (GameObject spawns in GameObject.FindGameObjectsWithTag("Respawn"))
            {
                Destroy(spawns);
            }
            GameObject.Find("goText").GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
            Debug.Log("Lives: " + lives);
    }
}
