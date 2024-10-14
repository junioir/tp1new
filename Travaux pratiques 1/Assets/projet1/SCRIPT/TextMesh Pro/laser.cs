using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float speed = 10f; // Vitesse du laser

    void Update()
    {
        // Déplace le laser vers l'avant dans la direction où il a été instancié
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si le laser touche un intercepteur
        if (other.CompareTag("Interceptor"))
        {
            Destroy(gameObject); // Détruit le laser en cas de collision
        }
    }

}
