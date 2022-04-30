using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text scoreText;
    public TMP_Text winsText;

    void Start()
    {
        if (PlayerPrefs.HasKey("time_played"))
        {
            timeText.text = PlayerPrefs.GetFloat("time_played").ToString();
        }
        else
        {
            timeText.text = "0";
        }
        if (PlayerPrefs.HasKey("high_score"))
        {
            scoreText.text = PlayerPrefs.GetInt("high_score").ToString();
        }
        else
        {
            scoreText.text = "0";
        }
        if (PlayerPrefs.HasKey("game_wins"))
        {
            winsText.text = PlayerPrefs.GetInt("game_wins").ToString();
        }
        else
        {
            winsText.text = "0";
        }
    }

    public void StartGame()
    {
        float tempTime = 0;
        int tempScore = 0;
        int tempWins = 0;

        if (PlayerPrefs.HasKey("time_played"))
        {
            tempTime = PlayerPrefs.GetFloat("time_played");
        }
        if (PlayerPrefs.HasKey("high_score"))
        {
            tempScore = PlayerPrefs.GetInt("high_score");
        }
        if (PlayerPrefs.HasKey("game_wins"))
        {
            tempWins = PlayerPrefs.GetInt("game_wins");
        }
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("time_played", tempTime);
        PlayerPrefs.SetInt("high_score", tempScore);
        PlayerPrefs.SetFloat("game_wins", tempWins);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    void OpenSettings()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
