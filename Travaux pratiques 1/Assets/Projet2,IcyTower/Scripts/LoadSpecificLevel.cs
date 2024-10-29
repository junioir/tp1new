using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LoadSpecificLevel : MonoBehaviour
{
    [SerializeField] private string SceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneName);
            
        }
    }

}
