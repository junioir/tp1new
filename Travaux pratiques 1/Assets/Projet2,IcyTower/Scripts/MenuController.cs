using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;

    [SerializeField] private string _SceneName;


    [SerializeField] private Animator _FadeSystem;


    private void Awake()
    {
        _FadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();

    }

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

            StartCoroutine(LoadNextScene()); // Remplacez par le nom exact de votre scène de jeu
        }
    }

    public IEnumerator LoadNextScene()
    {
        _FadeSystem.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(_SceneName);
    }
}
