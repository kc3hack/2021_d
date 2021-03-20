using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunningState : MonoBehaviour
{
    enum GameState
    {
        Start,
        Running,
        GameOver,
    }

    [SerializeField] UIManager uiManager;

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

        uiManager.UpdateScore((int)Mathf.Floor(score));

    }

    public bool CanJump()
    {
        return clicking;
    }

    public bool IsRunning()
    {
        return gameState == GameState.Running;
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
        uiManager.GameOver();
    }


}
