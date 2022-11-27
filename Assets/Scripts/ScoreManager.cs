using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int Score;

    public TextMeshProUGUI GameScoreText;
    public TextMeshProUGUI GameOverScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    public void Update()
    {
        var text = $"Score: {Score.ToString()}";
        GameScoreText.text = text;
        GameOverScoreText.text = text;
    }
}
