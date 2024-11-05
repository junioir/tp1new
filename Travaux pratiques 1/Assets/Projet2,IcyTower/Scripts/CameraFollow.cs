using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player; 
    [SerializeField] private float _heightOffset = 2.0f; 
    [SerializeField] private float _minHeight = 0.0f; 
    [SerializeField] private float _maxHeight = 20.0f; 
    [SerializeField] private float _cameraSpeed = 1.0f; 
    [SerializeField] private float _followThreshold = 1.0f; 
    [SerializeField] private GameObject _gameOverPanel; 
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private AudioClip _AudioClipdefeat;
    [SerializeField] private AudioSource _Audiosource;
    


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        // La caméra monte constamment
        Vector3 newPosition = transform.position;
        newPosition.y += _cameraSpeed * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, _minHeight, _maxHeight);
        transform.position = newPosition;

        // Vérifier si le joueur monte trop vite
        if (_player.position.y > transform.position.y + _followThreshold)
        {
            // Suivre le joueur
            newPosition.y = Mathf.Clamp(_player.position.y + _heightOffset, _minHeight, _maxHeight);
            transform.position = newPosition;
        }

         }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
           ShowGameOver();
          }
    }
    private void ShowGameOver()
    {
        _gameOverPanel.SetActive(true); // Active le panel de Game Over

        _textMeshProUGUI.text = "Game Over"; // Met à jour le texte de Game Over

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

       
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop();
        }

       AudioSource.PlayClipAtPoint(_AudioClipdefeat, transform.position);

       CameraFollow cameraController = FindObjectOfType<CameraFollow>();
        if (cameraController != null)
        {
            cameraController.enabled = false;
        }

    }

}
