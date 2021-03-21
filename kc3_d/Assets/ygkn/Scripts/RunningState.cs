using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunningState : MonoBehaviour
{
    public enum GameState
    {
        Start,
        Running,
        GameOver,
        Clear,
        End,
    }


    GameState gameState = GameState.Start;

    bool clicking = false;

    float score = 0;

    // Update is called once per frame
    void Update()
    {
        clicking = Input.GetMouseButton(0) || Input.touchCount > 0;

        if (gameState == GameState.Start && clicking) {
            gameState = GameState.Running;
        }

        if (gameState == GameState.Running) {
            score += Time.deltaTime;
        }


        if (score > 120) {
            gameState = GameState.Clear;
        }

        if ((gameState == GameState.Clear || gameState == GameState.GameOver) && clicking) {
            gameState = GameState.End;
        }
    }

    public bool CanJump()
    {
        return clicking;
    }

    public GameState GetState()
    {
        return gameState;
    }

    public int GetScore()
    {
        return (int)Mathf.Floor(score);
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
    }


}
