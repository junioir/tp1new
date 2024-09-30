using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasercode : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // Reference to the projectile prefab
    [SerializeField] private float laserSpeed = 10f; // Speed of the projectile
    [SerializeField] private float minFireInterval = 1f; // Minimum time between shots
    [SerializeField] private float maxFireInterval = 3f; // Maximum time between shots

    void Start()
    {
        // Start the firing coroutine
        StartCoroutine(FireProjectiles());
    }

    private IEnumerator FireProjectiles()
    {
        while (true)
        {
            // Wait for a random interval
            float fireInterval = Random.Range(minFireInterval, maxFireInterval);
            yield return new WaitForSeconds(fireInterval);

            // Instantiate the projectile
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        // Instantiate the projectile from  cannon's current position and rotation
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Set the projectile's velocity based on the cannon's rotation
        Vector2 direction = transform.up;
        //this is to set the speed
        projectile.GetComponent<Rigidbody2D>().velocity = direction * laserSpeed;
    }
}
