using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class ScoreManager : MonoBehaviour
{
    public int actualScore;
    public TMPro.TextMeshProUGUI highScoreText;
    public PlayerScore playerScore;
    public GameObject[] cuadrantes;

    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        SetHighestScore(); 
    }

    public void SetHighestScore()
    {
        actualScore = playerScore.GetScore();
        if(actualScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", actualScore);
            highScoreText.text = actualScore.ToString();
        }
    }
}
