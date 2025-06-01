using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private float _speed;
    private float _jumpForce;
    private bool _isGrounded;
    private bool _isFlipped;
    public float Speed
    {
        get { return _speed; }
        set {  _speed = value; }
    }
    public float JumpForce
    {
        get { return _jumpForce; }
        set { _jumpForce = value; }
    }
    public bool IsGrounded
    {
        get { return _isGrounded; }
        set { _isGrounded = value; }
    }
    public bool IsFlipped
    {
        get { return _isFlipped; }
        set { _isFlipped = value; }
    }
}
