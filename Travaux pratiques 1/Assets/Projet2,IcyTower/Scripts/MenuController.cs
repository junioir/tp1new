using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;

    [SerializeField] private string _SceneName;



    void Start()
    {
        nameInputField.onEndEdit.AddListener(delegate { StartGame(); });
    }

    void StartGame()
    {
        string playerName = nameInputField.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString("PlayerName", playerName);
            SceneManager.LoadScene(_SceneName);  // Remplacez par le nom exact de votre scène de jeu
        }
    }
}
