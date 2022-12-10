using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    public ScoreManager scoreManager;
    public Bird Bird;
    
    private void Start()
    {
        gameCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
        var data = SaveInterface.LoadFile();
        scoreManager.HighScore = data.highScore;
        if (data.BirdItems != null) Bird.SetUpBirdItems(data.BirdItems);
    }
    
    public void GameOver()
    {
        if (scoreManager.HighScore < scoreManager.Score)
        {
            scoreManager.HighScore = scoreManager.Score;
            var data = new GameData(scoreManager.Score);
            SaveInterface.SaveFile(data);
        }
        Handheld.Vibrate();
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);

        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene(0);
    }
    
    public void GoToCharacterScene()
    {
        SceneManager.LoadScene(2);
    }

    
}
