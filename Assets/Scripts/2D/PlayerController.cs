using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerInfo
{
    private float _horizontal;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        Speed = 5;
        JumpForce = 7;
        IsGrounded = true;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * Speed * _horizontal);
        FLipSprite();
        PlayMovementAnimation();
    }

    private void FLipSprite()
    {
        if (_horizontal > 0)
        {
            IsFlipped = false;
        }
        if (_horizontal < 0)
        {
            IsFlipped = true;
        }
        _spriteRenderer.flipX = IsFlipped;
    }

    private void PlayMovementAnimation()
    {
        if (_horizontal > 0 || _horizontal < 0)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            IsGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            IsGrounded = true;
        }
    }
}
