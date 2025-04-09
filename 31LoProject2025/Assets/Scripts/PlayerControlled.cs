using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D _rb;
    UpdateT _up;
    SpriteRenderer _spriteRenderer;

    bool facingRight = true;

    public float _jumpStrength = 7f;
    public float _playerSpeed = 7f;
    [SerializeField] float jumpTime = 0.35f;
    [SerializeField] float jumpMultiplier = 0.2f;



    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    float _inputHorizontal;
    bool jumpPressed;
    bool jumpHeld;
    bool jumpReleased;

    [SerializeField] bool isJumping;
    float jumpCounter;

    void Start()
    {
        animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _up = FindFirstObjectByType<UpdateT>();
    }

    void Update()
    {
        // Inputs
        _inputHorizontal = Input.GetAxisRaw("Horizontal");

        jumpPressed = Input.GetButtonDown("Jump");
        jumpHeld = Input.GetButton("Jump");
        jumpReleased = Input.GetButtonUp("Jump");

        // Start Jump
        if (jumpPressed && IsGrounded() && !_up._cutscene)
        {
            isJumping = true;
            jumpCounter = 0f;
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpStrength);
        }

        // Cancel jump early if released
        if (jumpReleased)
        {
            isJumping = false;
        }

        if (_rb.linearVelocity.x != 0 && IsGrounded())
        {
            animator.SetTrigger("Running");
        }
        else if (IsGrounded())
        {
            animator.SetTrigger("Idle");
        }

        if (_rb.linearVelocity.y > 2)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }

        if (_rb.linearVelocity.y < -2 && _rb.linearVelocity.y >= -10)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        }

        if (_rb.linearVelocity.y < -10)
        {
            animator.SetBool("FastFalling", true);
        }
        else
        {
            animator.SetBool("FastFalling", false);
        }

        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, Mathf.Clamp(_rb.linearVelocity.y, -20f, 10f));
    }

    void FixedUpdate()
    {
        // Horizontal movement
        if (!_up._cutscene)
        {
            _rb.linearVelocity = new Vector2(_inputHorizontal * _playerSpeed, _rb.linearVelocity.y);
        }

        // Variable jump height
        if (jumpHeld && isJumping)
        {
            jumpCounter += Time.fixedDeltaTime;
            if (jumpCounter < jumpTime)
            {
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpStrength + 2f);
            }
            else
            {
                isJumping = false;
            }
        }

        // Flip character sprite
        if (_inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (_inputHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0f, Vector2.down, castDistance, groundLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - Vector3.up * castDistance, boxSize);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        facingRight = !facingRight;
    }
}
