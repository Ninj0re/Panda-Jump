using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private ButtonController buttonController;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject[] lava;
    [SerializeField] private GameObject reviveButton;
    [SerializeField] private GameObject restartButton;
    private int score;

    public static bool isGameEnded;
    void Start()
    {
        reviveButton.SetActive(false);
        restartButton.SetActive(false);
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
    public void ShowUI()
    {
        reviveButton.SetActive(true);
        restartButton.SetActive(true);
    }

    public void Revive()
    {
        foreach (GameObject l in lava)
        {
            l.transform.position = new Vector2(l.transform.position.x, l.transform.position.y - 10);
        }
        buttonController.Resume();
        player.Revive();

        reviveButton.SetActive(false);
        restartButton.SetActive(false);

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
