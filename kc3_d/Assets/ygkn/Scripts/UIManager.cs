﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] GameObject gameOverText;

    [SerializeField] string scoreString = "すこあ: ";

    [SerializeField] Color gameOverColor = new Color(1, 0, 0);


    public void UpdateScore(int score)
    {
        scoreText.text = scoreString + score.ToString();
    }
    public void GameOver()
    {
        gameOverText.SetActive(true);
    }


}