using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DIRECTIONShip : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // R�cup�ration des entr�es horizontales et verticales
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Cr�ation du vecteur de mouvement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Normalisation du vecteur pour �viter un d�placement plus rapide en diagonale
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        // D�placement du vaisseau
        transform.Translate(movement * speed * Time.deltaTime);
    }



}
