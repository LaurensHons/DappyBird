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
    
    private void Start()
    {
        gameCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
        LoadFile();
    }
    
    public void GameOver()
    {
        if (scoreManager.HighScore < scoreManager.Score)
        {
            scoreManager.HighScore = scoreManager.Score;
            SaveFile();
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

    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        GameData data = new GameData(scoreManager.Score);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }
    
    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;
 
        if(File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }
 
        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData) bf.Deserialize(file);
        file.Close();
 
        scoreManager.HighScore = data.highScore;
    }
}
