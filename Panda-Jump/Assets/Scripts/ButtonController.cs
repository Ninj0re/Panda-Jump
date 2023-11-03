using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private bool paused;
    private float timeScale = 1;

    [SerializeField] private GameObject musicButton;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private RewardedAdsButton rewardAds;
    private bool musicActiveness = true;

    void Start()
    {
        if (PlayerPrefs.GetInt("musicActiveness", 1) == 0)
            musicActiveness = false;
        else
            musicActiveness = true;

        musicButton.GetComponent<Animator>().SetBool("active", musicActiveness);

        SetBackgroundMusic();

    }
    public void PauseButton()
    {
        if (EndGameManager.isGameEnded)
            return;
        if(paused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Resume()
    {
        if (!paused)
            return;

        paused = !paused;
        ButtonActiveness(false);

        if (EndGameManager.isGameEnded && Advertisement.isInitialized)
        {
            rewardAds.ShowAd(timeScale);
        }      
        else
        {   
            Time.timeScale = timeScale;
        }

        
    }
    public void Pause()
    {
        if (paused)
            return;

        paused = !paused;
        timeScale = Time.timeScale;
        Time.timeScale = 0;
        ButtonActiveness(true);
    }
    public void ButtonActiveness(bool activeness)
    {
        musicButton.SetActive(activeness);
        if(activeness)
        {
            musicButton.GetComponent<Animator>().SetBool("active", musicActiveness);
        }
    }

    public bool IsPaused()
    {
        return paused;
    }

    public void MusicButton()
    {
        musicActiveness = !musicActiveness;

        if (musicActiveness)
            PlayerPrefs.SetInt("musicActiveness", 1);
        else
            PlayerPrefs.SetInt("musicActiveness", 0);

        musicButton.GetComponent<Animator>().SetBool("active", musicActiveness);
        SetBackgroundMusic();
    }


    private void SetBackgroundMusic()
    {
        backgroundMusic.mute = !musicActiveness;
    }
}
