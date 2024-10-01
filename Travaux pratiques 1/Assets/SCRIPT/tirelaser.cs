using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirelaser : MonoBehaviour
{
    public GameObject projectilePrefab; // Le prefab du projectile
    public Transform tirPoint; // Le point de tir

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Vérifie si la touche espace est pressée
        {
            Tirer();
        }
    }

    void Tirer()
    {
        // Instancie le projectile à la position du tirPoint avec la rotation du tirPoint
        Quaternion rotation = tirPoint.rotation; // Récupère la rotation du tirPoint
        Instantiate(projectilePrefab, tirPoint.position, rotation); // Utilise le quaternion pour la rotation
    }
}
