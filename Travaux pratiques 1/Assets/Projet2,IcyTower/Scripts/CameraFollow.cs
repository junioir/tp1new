using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player; // R�f�rence au joueur
    [SerializeField] private float _heightOffset = 2.0f; // D�calage de hauteur par rapport au joueur
    [SerializeField] private float _minHeight = 0.0f; // Hauteur minimale de la cam�ra
    [SerializeField] private float _maxHeight = 20.0f; // Hauteur maximale de la cam�ra
    [SerializeField] private float _cameraSpeed = 1.0f; // Vitesse de mont�e de la cam�ra
    [SerializeField] private float _followThreshold = 1.0f; // Seuil pour suivre le joueur
                                                            // [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
                                                            // [SerializeField] private GameObject _gameOverPanel;



    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        // La cam�ra monte constamment
        Vector3 newPosition = transform.position;
        newPosition.y += _cameraSpeed * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, _minHeight, _maxHeight);
        transform.position = newPosition;

        // V�rifier si le joueur monte trop vite
        if (_player.position.y > transform.position.y + _followThreshold)
        {
            // Suivre le joueur
            newPosition.y = Mathf.Clamp(_player.position.y + _heightOffset, _minHeight, _maxHeight);
            transform.position = newPosition;
        }

        // V�rifier si le joueur est trop bas par rapport � la cam�ra
        if (_player.position.y < transform.position.y - _heightOffset)
        {
           // ShowGameOver();
        }
    }

   /*private void ShowGameOver()
    {
        _gameOverPanel.SetActive(true); // Active le panel de Game Over

        _textMeshProUGUI.text = "Game Over"; // Met � jour le texte de Game Over
    }*/
}
