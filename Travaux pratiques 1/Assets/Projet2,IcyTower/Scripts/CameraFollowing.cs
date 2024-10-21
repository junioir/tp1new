using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _player;           // R�f�rence au joueur
    [SerializeField] private float _cameraSpeed = 0.5f;     // Vitesse de la cam�ra ind�pendante
                                                            // [SerializeField] private float _playerFollowThreshold = 2f;  // Distance seuil pour suivre le joueur
                                                            // [SerializeField] private float _cameraOffsetY = 5f;   // Distance de la cam�ra par rapport au joueur
    [SerializeField] private Vector2 _cameraBounds;       // Limites de la tour (min Y, max Y)
    [SerializeField] private TextMeshProUGUI defeatText;


    private float _defaultCameraY;       // Position initiale de la cam�ra


    void Start()
    {
        // defeatText.gameObject.SetActive(false);        
        _defaultCameraY = transform.position.y;  // Sauvegarde de la position de d�part

    }

    void Update()
    {
        MoveCamera();   // Mouvement automatique de la cam�ra
        //CheckPlayerPosition();     // Suivi du joueur si n�cessaire
    }

    void MoveCamera()
    {
        // La cam�ra monte en continu avec Time.deltaTime
        Vector3 newPosition = transform.position;
        newPosition.y += _cameraSpeed * Time.deltaTime;

        // Confiner la cam�ra � l'int�rieur de la tour
        newPosition.y = Mathf.Clamp(newPosition.y, _cameraBounds.x, _cameraBounds.y);
        transform.position = newPosition;
    }
    /*
    void CheckPlayerPosition()
    {
        // Si le joueur monte au-dessus d'un seuil par rapport � la cam�ra, la cam�ra suit le joueur
        if (_player.position.y > transform.position.y + _playerFollowThreshold)
        {
            // La cam�ra suit le joueur uniquement s'il d�passe le seuil vertical
            Vector3 newCameraPosition = new Vector3(transform.position.x, _player.position.y - _cameraOffsetY, transform.position.z);
 
            // Confiner la cam�ra � l'int�rieur des limites d�finies
            newCameraPosition.y = Mathf.Clamp(newCameraPosition.y, _cameraBounds.x, _cameraBounds.y);
 
            transform.position = newCameraPosition;
        }
 
        //V�rifier si le joueur tombe trop bas par rapport � la cam�ra
        if (_player.position.y < transform.position.y)
        {
            // Le joueur est trop bas, il meurt (� adapter selon la logique du jeu)
            // Exemple : Reload de la sc�ne, ou d�clenchement d'une fin de jeu
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
