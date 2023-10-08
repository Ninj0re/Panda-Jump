using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static void SetHighScore(int score)
    {
        if(PlayerPrefs.GetInt("highscore", 0) < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        Debug.Log("Highscore is: "+ PlayerPrefs.GetInt("highscore", 0) +"!");
    }
}
