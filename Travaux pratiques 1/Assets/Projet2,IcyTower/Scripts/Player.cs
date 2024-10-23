using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;       // Vitesse de déplacement gauche-droite
    [SerializeField] private float _jumpForce = 5f;      // Force du saut
    [SerializeField] private LayerMask _groundLayer;      // La couche qui représente le sol
    [SerializeField] private Transform _groundCheck;      // Point de vérification pour savoir si le joueur est au sol
    [SerializeField] private float _groundCheckRadius = 0.1f;  // Rayon de détection du sol
    private bool _isGrounded;           // Est-ce que le joueur touche le sol ?

    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer SpriteRenderer;
    [SerializeField] private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
        CheckGround();

        flip(_rb.velocity.x);

       float characterVelocity=Mathf.Abs(_rb.velocity.x);

        animator.SetFloat("_speed", characterVelocity);

        if (_isGrounded && Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Isjumped", _isGrounded);
        }
        
    }

    void Move()
    {
        // Déplacement horizontal du joueur
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
        // Utilisation d'un Raycast pour vérifier si le joueur est au sol
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

    void flip(float _velocity)
    {
        if (_velocity > 0.1f) {

            SpriteRenderer.flipX = false;
 } 
        
        else if(_velocity < -0.1f) {
            SpriteRenderer.flipY = true;
        }
    }
}
