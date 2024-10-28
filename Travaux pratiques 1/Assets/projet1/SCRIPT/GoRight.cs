using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoRight : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] private float _speed = 3f;
    // Start is called before the first frame update

    public void GoRightFunction()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.right * _speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            Destroy(collision.gameObject);
        }
    }
}
