using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radarObstacles : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 20f;

    [SerializeField] private float _raycastDistance = 10f;

    void Update()
    {
        // Rotation de l'objet autour de l'axe Y
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);

        // Origine et direction du raycast
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        // Lancer le raycast
        RaycastHit hit;
        Debug.DrawRay(origin, direction * 40f, Color.red);

        if (Physics.Raycast(origin, direction, out hit, _raycastDistance))
        {
            // Vérifie si le raycast touche le joueur
            if (hit.collider.CompareTag("Player"))
            {
                // Détruit le joueur immédiatement
                Destroy(hit.collider.gameObject);
                Debug.Log("Le joueur a été détruit par le rayon !");
            }

            // Affiche les informations de l'objet touché dans la console
            float distance = hit.distance;
            Vector3 impactPoint = hit.point;
            string objectName = hit.collider.gameObject.name;
            Debug.Log($"Objet: {objectName}, Distance: {distance:F2}, Point d'impact: {impactPoint}, Position de l'objet: {hit.collider.transform.position}");
        }
        else
        {
            // Aucune collision détectée
            Debug.Log("Objet: 0, Distance: 0.00, Point d'impact: (0, 0, 0), Position de l'objet: (0, 0, 0)");
        }
    }
}
