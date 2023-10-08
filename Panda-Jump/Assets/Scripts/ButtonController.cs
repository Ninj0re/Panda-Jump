using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private bool paused;
    private float timeScale = 1;

    [SerializeField] private GameObject musicButton;
    [SerializeField] private GameObject soundButton;
    private bool musicActiveness = true;
    private bool soundActiveness = true;

    void Start()
    {
        if (PlayerPrefs.GetInt("musicActiveness", 1) == 0)
            musicActiveness = false;
        else
            musicActiveness = true;
        if (PlayerPrefs.GetInt("soundActiveness", 1) == 0)
            soundActiveness = false;
        else
            soundActiveness = true;
    }
    public void PauseButton()
    {
        if(paused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        paused = !paused;
    }
    private void Resume()
    {
        Time.timeScale = timeScale;
        ButtonActiveness(false);
    }
    private void Pause()
    {
        ButtonActiveness(true);
        timeScale = Time.timeScale;
        Time.timeScale = 0;
    }
    public void ButtonActiveness(bool activeness)
    {
        musicButton.SetActive(activeness);
        soundButton.SetActive(activeness);
        if(activeness)
        {
            musicButton.GetComponent<Animator>().SetBool("active", musicActiveness);
            soundButton.GetComponent<Animator>().SetBool("active", soundActiveness);
        }
    }

    public bool Paused()
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
    }

    public void SoundButton()
    {
        soundActiveness = !soundActiveness;

        if (soundActiveness)
            PlayerPrefs.SetInt("soundActiveness", 1);
        else
            PlayerPrefs.SetInt("soundActiveness", 0);

        soundButton.GetComponent<Animator>().SetBool("active", soundActiveness);
    }

}
