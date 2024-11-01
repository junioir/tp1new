using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class end : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI leaderboardText;

    void Start()
    {
        ShowLeaderboard();
    }

    void ShowLeaderboard()
    {
        leaderboardText.text = "Leaderboard:\n";
        for (int i = 1; i <= 5; i++)
        {
            string name = PlayerPrefs.GetString("HighScoreName" + i, "N/A");
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            leaderboardText.text += $"{i}. {name} - {score}\n";
        }
    }
}
