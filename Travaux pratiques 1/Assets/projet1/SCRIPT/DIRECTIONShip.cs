using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DIRECTIONShip : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Récupération des entrées horizontales et verticales
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Création du vecteur de mouvement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Normalisation du vecteur pour éviter un déplacement plus rapide en diagonale
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        // Déplacement du vaisseau
        transform.Translate(movement * speed * Time.deltaTime);
    }



}
