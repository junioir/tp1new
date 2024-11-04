using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [SerializeField] private AudioClip _Sound;

    [SerializeField] private AudioSource _Audiosource;

    private TrailRenderer _trail;

   /* private void Start()
    {
        // Ajoute un Trail Renderer � l'objet s'il n'est pas d�j� pr�sent
        _trail = gameObject.AddComponent<TrailRenderer>();

        


        // Personnalisation de la tra�n�e
        _trail.time = 0.5f; // Dur�e de la tra�n�e en secondes
      _trail.startWidth = 0.2f; // Largeur de d�but de la tra�n�e
        _trail.endWidth = 0f; // Largeur de fin de la tra�n�e
        _trail.material = new Material(Shader.Find("Standard")); // Mat�riau par d�faut
        _trail.startColor = Color.yellow;
        _trail.endColor = new Color(1, 1, 0, 0); // Couleur qui s'estompe vers la transparence
    }*/

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.CompareTag("Player"))
        {
           
            AudioSource.PlayClipAtPoint(_Sound,transform.position);

            Inventory._Instance.Addcoin(1,1);

            Destroy(gameObject);
        }
    }

}
