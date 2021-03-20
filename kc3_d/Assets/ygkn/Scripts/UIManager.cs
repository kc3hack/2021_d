using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] RunningState runningState;

    [SerializeField] string scoreString = "すこあ: ";

    void Update()
    {
        scoreText.text = scoreString + runningState.GetScore().ToString();
        gameOverText.SetActive(runningState.GetState() == RunningState.GameState.GameOver);
    }

}
