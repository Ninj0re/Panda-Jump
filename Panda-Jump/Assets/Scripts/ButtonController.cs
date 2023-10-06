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
        musicButton.GetComponent<Animator>().SetBool("active", musicActiveness);
    }

    public void SoundButton()
    {
        soundActiveness = !soundActiveness;
        soundButton.GetComponent<Animator>().SetBool("active", soundActiveness);
    }

}
