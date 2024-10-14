using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int  scor = 0;

    void Start()
    {
        UpdateScoreText(); 
    }

    public void IncrementScore()
    {
        scor++; 
        UpdateScoreText(); 
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + scor; 
    }
}
