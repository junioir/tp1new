using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPtaform : MonoBehaviour
{
    public float speed = 2f; // Vitesse de déplacement de la plateforme
    public float distance = 5f; // Distance maximale de déplacement
    private Vector3 startPosition;

    void Start()
    {
        // Enregistrer la position de départ de la plateforme
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculer le nouveau déplacement
        float newPosition = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPosition + new Vector3(newPosition, 0, 0);
    }
}
