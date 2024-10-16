using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _JumpSpeed = 3f;
    [SerializeField] private float _MoveSpeed = 5f;
    [SerializeField] private SpriteRenderer _SpriteRenderer;
    //[SerializeField] private List<int> _newlist;
    private Rigidbody2D _rg;
    private Vector2 _Velocity;
    private bool isTouching;


    // Start is called before the first frame update
    void Start()
    {
        //  _newlist.RemoveAt(_newlist.Count );
        //Debug.Log(_newlist.Count);


        _rg = GetComponent<Rigidbody2D>();
        _SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        NewUpdate();
    }

    void NewUpdate()
    {

        _Velocity = _rg.velocity;// Get the current velocity

        //horizontal movement

        if (Input.GetKey(KeyCode.A))
        {
            _Velocity.x = _MoveSpeed;//move right
            _SpriteRenderer.flipX = false;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            _Velocity.x = -_MoveSpeed;//move left
            _SpriteRenderer.flipX = true;

        }
        else
        {

            _Velocity.x = 0;// stop movement when no key is pressed
        }

        //to control jumping

        if (Input.GetKey(KeyCode.Space))
        {
            _Velocity.y = _JumpSpeed;//set vertical velocity for jumping


        }

        else
        {
            _Velocity.y = -_JumpSpeed;//set vertical velocity for jumping


        }

        _rg.velocity = _Velocity;//THis apply the updated velocity
    }


}



