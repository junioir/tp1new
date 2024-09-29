using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRIPT : MonoBehaviour

{
    
    [SerializeField] public float _speed;

    private Rigidbody2D _rigidbody;
    private float _rotationspeed=12f;
    private float _acceleration=3f;
    private float _maxSpeed=1f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody component is missing from this GameObject.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(new Vector3(0, 0, _rotationspeed * Time.deltaTime));

     }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -_rotationspeed * Time.deltaTime));

        }


        if (Input.GetKey(KeyCode.W))
        {
            _speed += _acceleration* Time.deltaTime;

            if (_speed >= _maxSpeed) {
                _speed = _maxSpeed;

                }

        }

        if (Input.GetKey(KeyCode.S))
        {
           _speed -=_acceleration* Time.deltaTime;
                }
            if (_speed <= 0)
        {
            _speed =0;
        }

       _rigidbody.velocity = transform.up*_speed;



    }    
}
