using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    private Vector3 _direction = new Vector3(0, 0, 0);
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        _direction = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            _direction.y = 1;

        }

        else if (Input.GetKey(KeyCode.S))
        {
            _direction.y = -1;
        }

        else
        {
            _direction.y = 0;
        }


        if (Input.GetKey(KeyCode.D)) { _direction.x = 1; }

        else if (Input.GetKey(KeyCode.E)) { _direction.x = -1; }
        else
        {
            _direction.x = 0;
        }

        _rb.velocity = _direction * _speed * Time.deltaTime;

        transform.position += _direction * _speed * Time.deltaTime;

    }
}
