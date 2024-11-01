using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        PlayerPrefs.SetInt("CurrentScore", score);
    }

    public void EndGame()
    {
        UpdateLeaderboard();
        SceneManager.LoadScene("End Menu");
    }

    private void UpdateLeaderboard()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        for (int i = 1; i <= 5; i++)
        {
            int savedScore = PlayerPrefs.GetInt("HighScore" + i, 0);
            if (score > savedScore)
            {
                for (int j = 5; j > i; j--)
                {
                    PlayerPrefs.SetInt("HighScore" + j, PlayerPrefs.GetInt("HighScore" + (j - 1), 0));
                    PlayerPrefs.SetString("HighScoreName" + j, PlayerPrefs.GetString("HighScoreName" + (j - 1), ""));
                }
                PlayerPrefs.SetInt("HighScore" + i, score);
                PlayerPrefs.SetString("HighScoreName" + i, playerName);
                break;
            }
        }
    }
}
