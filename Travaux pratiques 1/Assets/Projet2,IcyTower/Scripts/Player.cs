using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;       // Vitesse de d�placement gauche-droite
    [SerializeField] private float _jumpForce = 5f;      // Force du saut
    [SerializeField] private LayerMask _groundLayer;      // La couche qui repr�sente le sol
    [SerializeField] private Transform _groundCheck;      // Point de v�rification pour savoir si le joueur est au sol
    [SerializeField] private float _groundCheckRadius = 0.1f;  // Rayon de d�tection du sol
    private bool _isGrounded;           // Est-ce que le joueur touche le sol ?

    //[SerializeField] Animator animator;

    [SerializeField] private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        CheckGround();

       /* float characterVelocity=Mathf.Abs(_rb.velocity.x);

        animator.SetFloat("_speed", characterVelocity);

        if (_isGrounded==true)
        {
            animator.SetBool("Isjumped", _isGrounded);
        }
        */
    }

    void Move()
    {
        // D�placement horizontal du joueur
        float move = Input.GetAxis("Horizontal") * _moveSpeed;
        _rb.velocity = new Vector2(move, _rb.velocity.y);
    }

    void Jump()
    {
        // Si le joueur est au sol et appuie sur la touche saut
        if (_isGrounded && Input.GetKey(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    void CheckGround()
    {
        // Utilisation d'un Raycast pour v�rifier si le joueur est au sol
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }
}
