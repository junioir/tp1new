using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaisofuite : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser") || other.CompareTag("Interceptor"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject); // Si c'est un laser
        }
    }
}
