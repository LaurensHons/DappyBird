using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    
    private void Start()
    {
        gameCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void GameOver()
    {
        Handheld.Vibrate();
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);

        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
