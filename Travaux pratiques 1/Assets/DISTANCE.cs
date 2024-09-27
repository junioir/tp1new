using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DISTANCE : MonoBehaviour
{
    [SerializeField] Transform _A;
    [SerializeField] Transform _B;
    private Rigidbody2D _rigidbody;
    [SerializeField] float _speed=4f;
    [SerializeField] private SpriteRenderer _SpriteRenderer;
        
        void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _SpriteRenderer.color = Color.green;

        
    }

    // Update is called once per frame
   

    void FixedUpdate()
    {
        Vector3 Direction = (_B.position - _A.position).normalized;

        float distance= (_B.position - _A.position).magnitude;
        if (distance < 5)
        {
            _SpriteRenderer.color = Color.green;
        }
        else { 
            _SpriteRenderer.color = Color.red;
        }
        _A.position += Direction * Time.deltaTime;

        _rigidbody.velocity = Direction * _speed;

    }

}
