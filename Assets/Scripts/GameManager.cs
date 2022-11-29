using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int score;

    public void IncreaseScore()
    {
        score++;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
