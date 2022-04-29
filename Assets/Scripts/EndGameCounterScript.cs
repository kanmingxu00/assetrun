using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCounterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("game_wins"))
        {   
            PlayerPrefs.SetInt("game_wins", PlayerPrefs.GetInt("game_wins") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("game_wins", 0);
        }
        if (PlayerPrefs.HasKey("high_score"))
        {
            if (PlayerPrefs.GetInt("high_score") < PlayerPrefs.GetInt("score"))
            {
                PlayerPrefs.SetInt("high_score", PlayerPrefs.GetInt("score"));
            }
        }
        else
        {
            PlayerPrefs.SetInt("high_score", PlayerPrefs.GetInt("score"));    
        }
        PlayerPrefs.DeleteKey("score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
