using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int finalScore = 10;
    public Text gameText;
    public Text scoreText;
    public Text moneyText;
    public Text bitcoinText;
    public AudioClip gameOverSFX;
    public AudioClip winSFX;
    public AudioSource backgroundMusic;
    public static bool isGameOver;
    public static bool isWon;
    public string levelName;
    public static int score;
    public GameObject player;
    private PlayerHealth playerHealth;
    private int buildIndex;
    // Start is called before the first frame update
    public static int playerProjectileDamage = 10;
    float timePlayed;
    public GameObject UI;
    private void Awake()
    {
        isGameOver = false;
        isWon = false;
        gameText.enabled = false;
        score = 0;
        backgroundMusic.enabled = true;
        player = GameObject.FindGameObjectWithTag("Player");

        playerHealth = player.GetComponent<PlayerHealth>();


    }

    void Start()
    {
        // set countDown to level duration specified in the inspector
        isGameOver = false;
        gameText.enabled = false;
        backgroundMusic = Camera.main.GetComponent<AudioSource>();
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
        }
        if (PlayerPrefs.HasKey("time_played"))
        {
            timePlayed = PlayerPrefs.GetFloat("time_played");
        }
        else
        {
            timePlayed = 0.0f;
        }
        Debug.Log(timePlayed);
    }

    // Update is called once per frame
    void Update()
    {

        // decrement countDown value while it's not zero
        if (!isGameOver)
        {
            if (playerHealth.currentHealth <= 0)
            {
                LevelLost();
            }
            //if (score > finalScore)
            //{
            //    LevelBeat();
            //}
        }
        timePlayed += Time.deltaTime;

        SetScoreText();
        SetCurrencyText();
    }

    void SetCurrencyText()
    {
        moneyText.text = "Money: " + Database.money;
        bitcoinText.text = "Bitcoin: " + Database.bitcoin;
    }


    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetGameOverStatus(string gameTextMessage, AudioClip statusSFX)
    {
        /// <summary>method to set GameOver status</summary>
        /// 

        // set isGameOver 
        isGameOver = true;
        
        PlayerPrefs.SetFloat("time_played", timePlayed);
        
        // update gameText UI component with appropriate mess@kage and activate it
        // message is received as an argument
        gameText.text = gameTextMessage;
        gameText.enabled = true;

        // play level status sfx
        // sfx clip is received as an argument
        AudioSource.PlayClipAtPoint(statusSFX, Camera.main.transform.position);

    }
    public void LevelLost()
    {
        /// <summary>method to specify what happens when the level is lost</summary>
        /// 

        // call SetGameOverStatus with "GAME OVER!"
        SetGameOverStatus("GAME OVER!", gameOverSFX);

        backgroundMusic.enabled = false;
        Invoke("LoadCurrentLevel", 2);
    }

    public void LevelBeat()
    {

        isWon = true;
        /// <summary>method to specify what happens when the level is won</summary>
        ///
        UI.SetActive(false);
        gameObject.GetComponent<Fade>().FadeMe();
        // call SetGameOverStatus with "YOU WIN!"
        SetGameOverStatus("YOU WIN!", winSFX);
        PlayerPrefs.SetInt("score", score);

        backgroundMusic.enabled = false;
        if (SceneManager.GetActiveScene().buildIndex < 4)
        {
            Invoke("LoadNextLevel", 2);
        }
        

    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(buildIndex + 1);
    }

    void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
