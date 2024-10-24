using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;
    private Transform _targets;
    private int _despoint;
    [SerializeField] private SpriteRenderer _graphics;
    
    void Start()
    {
        _targets = _waypoints[0];
            
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = _targets.position - transform.position; 
        transform.Translate(dir.normalized*_speed*Time.deltaTime,Space.World);

        if (Vector3.Distance(transform.position,_targets.position)<0.3f)
        {
            _despoint=(_despoint+1) % _waypoints.Length;
            _targets=_waypoints[_despoint];
            _graphics.flipX = !_graphics.flipX;


        }


        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            
            Destroy(collision.gameObject);
        }

    }

}

