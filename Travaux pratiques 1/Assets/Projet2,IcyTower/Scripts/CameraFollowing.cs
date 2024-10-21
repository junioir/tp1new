using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _player;           // Référence au joueur
    [SerializeField] private float _cameraSpeed = 0.5f;     // Vitesse de la caméra indépendante
                                                            // [SerializeField] private float _playerFollowThreshold = 2f;  // Distance seuil pour suivre le joueur
                                                            // [SerializeField] private float _cameraOffsetY = 5f;   // Distance de la caméra par rapport au joueur
    [SerializeField] private Vector2 _cameraBounds;       // Limites de la tour (min Y, max Y)
    [SerializeField] private TextMeshProUGUI defeatText;


    private float _defaultCameraY;       // Position initiale de la caméra


    void Start()
    {
        // defeatText.gameObject.SetActive(false);        
        _defaultCameraY = transform.position.y;  // Sauvegarde de la position de départ

    }

    void Update()
    {
        MoveCamera();   // Mouvement automatique de la caméra
        //CheckPlayerPosition();     // Suivi du joueur si nécessaire
    }

    void MoveCamera()
    {
        // La caméra monte en continu avec Time.deltaTime
        Vector3 newPosition = transform.position;
        newPosition.y += _cameraSpeed * Time.deltaTime;

        // Confiner la caméra à l'intérieur de la tour
        newPosition.y = Mathf.Clamp(newPosition.y, _cameraBounds.x, _cameraBounds.y);
        transform.position = newPosition;
    }
    /*
    void CheckPlayerPosition()
    {
        // Si le joueur monte au-dessus d'un seuil par rapport à la caméra, la caméra suit le joueur
        if (_player.position.y > transform.position.y + _playerFollowThreshold)
        {
            // La caméra suit le joueur uniquement s'il dépasse le seuil vertical
            Vector3 newCameraPosition = new Vector3(transform.position.x, _player.position.y - _cameraOffsetY, transform.position.z);
 
            // Confiner la caméra à l'intérieur des limites définies
            newCameraPosition.y = Mathf.Clamp(newCameraPosition.y, _cameraBounds.x, _cameraBounds.y);
 
            transform.position = newCameraPosition;
        }
 
        //Vérifier si le joueur tombe trop bas par rapport à la caméra
        if (_player.position.y < transform.position.y)
        {
            // Le joueur est trop bas, il meurt (à adapter selon la logique du jeu)
            // Exemple : Reload de la scène, ou déclenchement d'une fin de jeu
            //Debug.Log("Game Over! Le joueur est hors du champ de vision.");
            // PlayerDied();
        }
    }*/

    void PlayerDied()
    {
        defeatText.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Game Over! Le joueur est hors du champ de vision");
    }
}
