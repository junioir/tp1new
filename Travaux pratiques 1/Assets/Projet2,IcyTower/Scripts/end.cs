using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class end : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI leaderboardText;

    [SerializeField] private GameObject _gameOverPanel; // Référence au panel de Game Over

    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    void Start()
    {
        ShowLeaderboard();

        _gameOverPanel.SetActive(true); // Active le panel de Game Over

        _textMeshProUGUI.text = "Congrate you have WIN"; // Met à jour le texte de Game Over

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
