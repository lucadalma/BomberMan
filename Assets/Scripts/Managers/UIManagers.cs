using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagers : MonoBehaviour
{

    public GameObject StartMenuCanvas;
    public GameObject PauseMenuCanvas;
    public GameObject InGameCanvas;
    public GameObject EndGameCanvas;
    public GameObject playerWin;
    public GameObject gameOver;


    public void StartGameUI() 
    {
        StartMenuCanvas.SetActive(true);
        PauseMenuCanvas.SetActive(false);
        InGameCanvas.SetActive(false);
        EndGameCanvas.SetActive(false);
    }

    public void PauseGameUI()
    {
        StartMenuCanvas.SetActive(false);
        InGameCanvas.SetActive(false);
        PauseMenuCanvas.SetActive(true);
        EndGameCanvas.SetActive(false);
    }

    public void RunningGameUI()
    {
        StartMenuCanvas.SetActive(false);
        InGameCanvas.SetActive(true);
        PauseMenuCanvas.SetActive(false);
        EndGameCanvas.SetActive(false);
    }

    public void EndGameUI()
    {
        StartMenuCanvas.SetActive(false);
        InGameCanvas.SetActive(false);
        PauseMenuCanvas.SetActive(false);
        EndGameCanvas.SetActive(true);
    }

    public void PlayerWinUI() 
    {
        playerWin.SetActive(true);
        gameOver.SetActive(false);
    }

    public void GameOverUI()
    {
        playerWin.SetActive(false);
        gameOver.SetActive(true);
    }

}
