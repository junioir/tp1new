using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    public GameObject laserPrefab; // Référence au prefab du laser
    public float minFireRate = 1f; // Taux de tir minimum en secondes
    public float maxFireRate = 3f; // Taux de tir maximum en secondes
    public float rotationSpeed = 30f; // Vitesse de rotation en degrés par seconde

    private float targetAngle; // Angle cible pour la rotation
    private float rotationDirection = 1f; // Direction de rotation

    void Start()
    {
        targetAngle = 45f; // Angle de départ
        StartCoroutine(FireWithRandomIntervals()); // Démarre le tir avec des intervalles aléatoires
    }

    void Update()
    {
        // Rotation du canon
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, targetAngle), rotationSpeed * Time.deltaTime);

        // Changer la direction de rotation lorsque l'angle cible est atteint
        if (Mathf.Abs(transform.eulerAngles.z - targetAngle) < 0.1f)
        {
            rotationDirection *= -1; // Inverse la direction de rotation
            targetAngle = Mathf.Clamp(targetAngle + (rotationDirection * 50f), -50f, 50f); // Détermine le nouvel angle cible
        }
    }

    private IEnumerator FireWithRandomIntervals()
    {
        while (true)
        {
            Fire();
            float randomDelay = Random.Range(minFireRate, maxFireRate);
            yield return new WaitForSeconds(randomDelay); // Attend un délai aléatoire avant de tirer à nouveau
        }
    }

    void Fire()
    {
        // Instancie le laser à la position du canon avec l'orientation actuelle
        GameObject laser = Instantiate(laserPrefab, transform.position, transform.rotation);
        Destroy(laser, 20f); // Détruit le laser après 20 secondes
    }

}



