using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRIPT : MonoBehaviour

{
    
    [SerializeField] public float _speed;

    private Rigidbody _rigidbody;
    private float _rotationspeed=30f;
    private float a=1f;
    private float b;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody component is missing from this GameObject.");
        }

    }

    // Update is called once per frame
    void FixedUpdate()
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
            _speed += a * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.S))
        {
           _speed -=a* Time.deltaTime;

        }

       //rigidbody.velocity = transform.up*_speed;



    }    
}
