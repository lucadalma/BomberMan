using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public enum GameStatus 
    {
        MainMenu,
        GameRunning,
        GamePause,
        EndGame
    }

    public enum GameResult 
    {
        PlayerWin,
        GameOver
    }

    public Text enemyCount;
    public int numberEnemy;
    public GameResult gameResult;
    public GameStatus gameStatus;

    UIManagers uIManager;

    void Start()
    {
        uIManager = FindObjectOfType<UIManagers>();
        gameStatus = GameStatus.MainMenu;
    }

    void Update()
    {
        if (gameStatus == GameStatus.MainMenu)
        {
            Time.timeScale = 0;
            uIManager.StartGameUI();
        } 
        else if (gameStatus == GameStatus.GameRunning) 
        {
            Time.timeScale = 1;
            uIManager.RunningGameUI();
        }
        else if (gameStatus == GameStatus.GamePause)
        {
            Time.timeScale = 0;
            uIManager.PauseGameUI();
        }
        else if (gameStatus == GameStatus.EndGame)
        {
            Time.timeScale = 0;
            uIManager.EndGameUI();
        }

        if (gameResult == GameResult.PlayerWin)
        {
            uIManager.PlayerWinUI();
        }
        else if (gameResult == GameResult.GameOver) 
        {
            uIManager.GameOverUI();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (gameStatus == GameStatus.GameRunning)
            {
                gameStatus = GameStatus.GamePause;
            }
            else if (gameStatus == GameStatus.GamePause) 
            {
                gameStatus = GameStatus.GameRunning;
            }
        }

        enemyCount.text = numberEnemy.ToString();

        if (numberEnemy == 0) 
        {
            gameStatus = GameStatus.EndGame;
            gameResult = GameResult.PlayerWin;
        }


    }

    public void StartGame() 
    {
        gameStatus = GameStatus.GameRunning;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToMainMenu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
