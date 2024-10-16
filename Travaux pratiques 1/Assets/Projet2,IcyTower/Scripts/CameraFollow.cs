using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player; // R�f�rence au joueur
    [SerializeField] private float cameraSpeed = 2f; // Vitesse constante � laquelle la cam�ra monte
    [SerializeField] private float playerCatchUpSpeed = 3f; // Vitesse � laquelle la cam�ra rattrape le joueur s'il va trop vite
    [SerializeField] private float maxDistanceBelowCamera = 5f; // Distance maximale entre le joueur et la cam�ra avant que le joueur ne meure
    [SerializeField] private Vector2 towerBounds; // Limites de la tour (x = largeur, y = hauteur)
    [SerializeField] private float playerSpeedThreshold = 2f; // Vitesse du joueur au-dessus de laquelle la cam�ra le suit

    void Update()
    {
        // Faire monter la cam�ra constamment
        transform.position += Vector3.up * cameraSpeed * Time.deltaTime;

        // Suivre le joueur seulement s'il monte trop vite
        if (player.GetComponent<Rigidbody2D>().velocity.y > playerSpeedThreshold)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = Mathf.Lerp(transform.position.y, player.position.y, playerCatchUpSpeed * Time.deltaTime);
            transform.position = newPosition;
        }

        // Confiner la cam�ra dans les limites de la tour
        float clampedX = Mathf.Clamp(transform.position.x, -towerBounds.x / 2, towerBounds.x / 2);
        float clampedY = Mathf.Clamp(transform.position.y, 0, towerBounds.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        // V�rifier si le joueur est en dehors du champ de vision (trop bas par rapport � la cam�ra)
        if (player.position.y < transform.position.y - maxDistanceBelowCamera)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        // D�truire le joueur ou lancer une animation de mort
        Debug.Log("Le joueur est trop bas et a p�ri !");
        Destroy(player.gameObject);
    }
}
