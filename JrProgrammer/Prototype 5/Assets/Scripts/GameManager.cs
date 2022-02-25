using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI  scoreText,
                            livesText,
                            gameOverText;
    public Button           restartButton,
                            PausePlayButton;
    public Slider           soundSlider;
    public GameObject titleScreen,
                      pauseScreen;
    public bool isGameActive;

    private float spawnRate = 1.0f;
    private int score,
                lives = 3;
    private AudioSource gameMusic;
    private bool isPaused = false;



    // Start is called before the first frame update
    void Start()
    {
        gameMusic = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);            
        }
    }

    public void UpdateScore(int scoreMod)
    {
        score += scoreMod;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesMod)
    {
        lives += livesMod;
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
            GameOver();
    }

    public void UpdateSoundValue()
    {
        gameMusic.volume = soundSlider.value;
    }

    private void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        PausePlayButton.gameObject.SetActive(false);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PausePlayGame()
    {        
        isPaused = !isPaused;
        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        pauseScreen.SetActive(isPaused);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;

        isGameActive = true;
        score = 0; 
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(0);
        titleScreen.SetActive(false);
        PausePlayButton.gameObject.SetActive(true);
    }
}
