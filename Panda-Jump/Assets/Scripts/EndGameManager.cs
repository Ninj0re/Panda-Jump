using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private ButtonController buttonController;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject[] lava;
    [SerializeField] private GameObject endGameButtons;
    private int score;

    public static bool isGameEnded;
    void Start()
    {
        UnShowUI();
    }
    public void EndGameScreen(int score)
    {
        buttonController.Pause();
        this.score = score;
        isGameEnded = true;
        ShowUI();
    }
    private void SetHighScore()
    {
        if (PlayerPrefs.GetInt("highscore", 0) < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        Debug.Log("Highscore is: "+ PlayerPrefs.GetInt("highscore", 0) +"!");
    }

    private void UIManager(bool activeness, GameObject o)
    {
        Transform buttons = o.transform;
        for (int i = 0; i < buttons.childCount; i++)
        {
            buttons.GetChild(i).gameObject.SetActive(activeness);
            if (buttons.transform.childCount != 0)
            {
                UIManager(activeness, buttons.GetChild(i).gameObject);
            }
        }
    }
    public void ShowUI()
    {
        UIManager(true, endGameButtons);
    }
    public void UnShowUI()
    {
        UIManager(false, endGameButtons);
    }

    public void Revive()
    {
        foreach (GameObject l in lava)
        {
            l.transform.position = new Vector2(l.transform.position.x, l.transform.position.y - 10);
        }
        buttonController.Resume();
        player.Revive();

        UnShowUI();

        isGameEnded = false;
    }

    public void Restart()
    {
        isGameEnded = false;
        Time.timeScale = 1;
        SetHighScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
