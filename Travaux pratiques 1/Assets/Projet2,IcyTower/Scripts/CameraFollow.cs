using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player; // Référence au joueur
    [SerializeField] private float cameraSpeed = 2f; // Vitesse constante à laquelle la caméra monte
    [SerializeField] private float playerCatchUpSpeed = 3f; // Vitesse à laquelle la caméra rattrape le joueur s'il va trop vite
    [SerializeField] private float maxDistanceBelowCamera = 5f; // Distance maximale entre le joueur et la caméra avant que le joueur ne meure
    [SerializeField] private Vector2 towerBounds; // Limites de la tour (x = largeur, y = hauteur)
    [SerializeField] private float playerSpeedThreshold = 2f; // Vitesse du joueur au-dessus de laquelle la caméra le suit

    void Update()
    {
        // Faire monter la caméra constamment
        transform.position += Vector3.up * cameraSpeed * Time.deltaTime;

        // Suivre le joueur seulement s'il monte trop vite
        if (player.GetComponent<Rigidbody2D>().velocity.y > playerSpeedThreshold)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = Mathf.Lerp(transform.position.y, player.position.y, playerCatchUpSpeed * Time.deltaTime);
            transform.position = newPosition;
        }

        // Confiner la caméra dans les limites de la tour
        float clampedX = Mathf.Clamp(transform.position.x, -towerBounds.x / 2, towerBounds.x / 2);
        float clampedY = Mathf.Clamp(transform.position.y, 0, towerBounds.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        // Vérifier si le joueur est en dehors du champ de vision (trop bas par rapport à la caméra)
        if (player.position.y < transform.position.y - maxDistanceBelowCamera)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        // Détruire le joueur ou lancer une animation de mort
        Debug.Log("Le joueur est trop bas et a péri !");
        Destroy(player.gameObject);
    }
}
