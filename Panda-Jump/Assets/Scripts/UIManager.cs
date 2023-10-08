using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text startText;
    [SerializeField] private ButtonController buttonController;
    [SerializeField] private PlayerMovement pm;

    void Start()
    {
        PlayerData();
    }

    void Update()
    {
        PlayerData();    
    }

    public void StartGame()
    {
        scoreText.enabled = true;
        startText.enabled = false;
        buttonController.ButtonActiveness(false);
    }

    private void PlayerData()
    {
        coinText.text = "" + PlayerPrefs.GetInt("coin", 0);
        scoreText.text = "" + pm.GetScore();
    }
}
