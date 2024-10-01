using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaissequx : MonoBehaviour
{
    public float speed = 5f;
    public GameObject laserPrefab;
    public Transform firePoint;
    public int shield = 3;

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Move()
    {
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, move, 0);
    }

    void Shoot()
    {
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
    }

    public void TakeDamage()
    {
        shield--;
        if (shield <= 0)
        {
            // Gérer la destruction de l'intercepteur
            Destroy(gameObject);
        }
    }
}
