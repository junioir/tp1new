using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float speed = 10f; // Vitesse du laser

    void Update()
    {
        // D�place le laser vers l'avant dans la direction o� il a �t� instanci�
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // V�rifie si le laser touche un intercepteur
        if (other.CompareTag("Interceptor"))
        {
            Destroy(gameObject); // D�truit le laser en cas de collision
        }
    }

}
