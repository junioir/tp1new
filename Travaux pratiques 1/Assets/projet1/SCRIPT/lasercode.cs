using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasercode : MonoBehaviour
{
    [SerializeField] private GameObject _ProjectilePrefab; 
    [SerializeField] private float _LaserSpeed = 10f;
    [SerializeField] private float _MinFireInterval = 1f; 
    [SerializeField] private float _MaxFireInterval = 3f; 

    void Start()
    {
        
        StartCoroutine(FireProjectiles());
    }

    private IEnumerator FireProjectiles()
    {
        while (true)
        {
            
            float fireInterval = Random.Range(_MinFireInterval, _MaxFireInterval);
            yield return new WaitForSeconds(fireInterval);

            
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
       
        GameObject projectile = Instantiate(_ProjectilePrefab, transform.position, transform.rotation);

       
        Vector2 direction = transform.up;
      
        projectile.GetComponent<Rigidbody2D>().velocity = direction * _LaserSpeed;
    }
}
