using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class LoadSpecificLevel : MonoBehaviour
{
    [SerializeField] private string _SceneName;

    [SerializeField] private Animator _FadeSystem;



    private void Awake()
    {
        _FadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))

        {
           StartCoroutine(LoadNextScene());
             
         }
    }

    public IEnumerator LoadNextScene()
    {
        _FadeSystem.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);
         
        SceneManager.LoadScene(_SceneName);
    }


}
