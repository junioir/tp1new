using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirelaser : MonoBehaviour
{
    public GameObject projectilePrefab; // Le prefab du projectile
    public Transform tirPoint; // Le point de tir

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // V�rifie si la touche espace est press�e
        {
            Tirer();
        }
    }

    void Tirer()
    {
        // Instancie le projectile � la position du tirPoint avec la rotation du tirPoint
        Quaternion rotation = tirPoint.rotation; // R�cup�re la rotation du tirPoint
        Instantiate(projectilePrefab, tirPoint.position, rotation); // Utilise le quaternion pour la rotation
    }
}
