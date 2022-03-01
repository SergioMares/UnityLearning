using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;

    [SerializeField]
    private ParticleSystem explosionParticle,
                           dirtParticle;
    [SerializeField]
    private AudioClip crashSound,
                      jumpSound;

    private AudioSource playerAudio;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private GameObject GameOverScreen;

    public float jumpForce = 10, 
                 gravityMod = 1,
                 score = 0,
                 speed = 10;
    public bool isOnGround = true,
                gameOver = true,
                speedUp = false,
                inPlace = false;
    private int jumps = 0,
                scoreMod = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity = Vector3.down * 10;
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 0 && !inPlace)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 2);
        }
        else if(!inPlace)
        {
            inPlace = true;
            gameOver = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || jumps < 2) && !gameOver) 
        {
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound);
            jumps++;
            isOnGround = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            speedUp = true;
            scoreMod = 4;
            playerAnim.speed *= 2;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            speedUp = false;
            scoreMod = 1;
            playerAnim.speed /= 2;
        }
        if (!gameOver)
        {
            score += Time.deltaTime * scoreMod;
            scoreText.text = "Score: " + ((int)score);
        }

        speed += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumps = 0;
            dirtParticle.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            
            explosionParticle.Play();
            dirtParticle.Stop();

            playerAudio.PlayOneShot(crashSound);


            gameOver = true;
            GameOverScreen.SetActive(true);
        }        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}