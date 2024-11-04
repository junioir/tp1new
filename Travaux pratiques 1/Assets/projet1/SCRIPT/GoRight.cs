using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoRight : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] private float _speed = 3f;


    [SerializeField] private AudioClip _Sound;

    [SerializeField] private AudioSource _Audiosource;


    public void GoRightFunction()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.right * _speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            Destroy(collision.gameObject);

            AudioSource.PlayClipAtPoint(_Sound, transform.position);
        }
    }
}
