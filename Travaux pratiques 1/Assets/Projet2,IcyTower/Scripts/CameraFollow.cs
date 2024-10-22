using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player; // Référence au joueur
    [SerializeField] private float _heightOffset = 2.0f; // Décalage de hauteur par rapport au joueur
    [SerializeField] private float _minHeight = 0.0f; // Hauteur minimale de la caméra
    [SerializeField] private float _maxHeight = 20.0f; // Hauteur maximale de la caméra
    [SerializeField] private float _cameraSpeed = 1.0f; // Vitesse de montée de la caméra
    [SerializeField] private float _followThreshold = 1.0f; // Seuil pour suivre le joueur

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

        // Vérifier si le joueur est trop bas par rapport à la caméra
        if (_player.position.y < transform.position.y - _heightOffset)
        {
            // Le joueur est en dehors du champ de vision, il perd
            Debug.Log("Le joueur a péri !");
            // Ici, vous pouvez appeler une méthode pour gérer la défaite du joueur
            // Par exemple, appeler une méthode pour afficher un écran de défaite
        }
    }
}
