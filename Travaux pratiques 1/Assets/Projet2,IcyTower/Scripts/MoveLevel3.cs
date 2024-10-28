using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevel3 : MonoBehaviour
{


    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _distance = 5f; 
    [SerializeField] private float _invisibleDuration = 1f; 
    [SerializeField] private float _visibleDuration = 3f; 

    private Vector3 _startPosition;
    private bool _isInvisible = false; 
    private float _timer = 0f; 
    private Renderer _renderer; 

    void Start()
    {
        
        _startPosition = transform.position;

        
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
       
        float _NewPosition = Mathf.PingPong(Time.time * _speed, _distance);
        transform.position = _startPosition + new Vector3(_NewPosition, 0, 0);

        
        _timer += Time.deltaTime;

        if (_isInvisible)
        {
            
            if (_timer >= _invisibleDuration)
            {
                _renderer.enabled = true;
                _isInvisible = false;
                _timer = 0f;
            }
        }
        else
        {
          
            if (_timer >= _visibleDuration)
            {
                _renderer.enabled = false;
                _isInvisible = true;
                _timer = 0f;
            }
        }
    }
}



