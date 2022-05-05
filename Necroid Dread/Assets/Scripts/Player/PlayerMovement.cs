using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public Transform feet;
    public float runSpeed = 20f;
    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = .02f;
    private Rigidbody2D _rigidbody;
    public float jumpForce = 10f;
    bool isGrounded = true;
    float checkRadius = 0.1f;
    public float crouchSpeedReduction = 0.5f;
    public Joystick joystick;
    private float horizontalSpeed;
    private BoxCollider2D boxCollider;
    public Animator animator;
    public bool flipped = false;
    public bool upgrade = false;
    public bool final = false;
    int numOfJumps = 0;
    private bool wallSliding;
    public float wallSlidingSpeed;
    private bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    private int wallJumps = 2;
    private bool isTouchingFront;
    public Transform frontCheck;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Flip();
        isGrounded = Physics2D.OverlapCircle(feet.position, checkRadius, platformLayerMask);
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, platformLayerMask);

        if (joystick.Horizontal >= 0.2f)
        {
            horizontalSpeed = runSpeed;
        }
        else if (joystick.Horizontal <= -0.2f)
        {
            horizontalSpeed = -runSpeed;
        }
        else
        {
            horizontalSpeed = 0;
        }
        animator.SetFloat("speed", Mathf.Abs(horizontalSpeed));

        if (isTouchingFront && !isGrounded && horizontalSpeed != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallJumps == 0 && isGrounded)
        {
            wallJumps = 2;
        }

        if (wallSliding)
        {
            if (upgrade)
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Mathf.Clamp(_rigidbody.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
    }

    private void FixedUpdate()
    {
        if (joystick.Vertical <= -0.7f && isGrounded)
        {
            Vector3 targetVelocity = new Vector2(horizontalSpeed * crouchSpeedReduction, _rigidbody.velocity.y);
            _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            boxCollider.enabled = false;
        }
        else
        {
            Vector3 targetVelocity = new Vector2(horizontalSpeed, _rigidbody.velocity.y);
            _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            boxCollider.enabled = true;
        }
        if (isGrounded)
            numOfJumps = 0;
    }

    public void Jump()
    {
        if (upgrade)
        {
            if (numOfJumps < 2)
            {
                if (isGrounded)
                {
                    animator.SetTrigger("jump");
                    _rigidbody.velocity = Vector2.up * jumpForce;
                }
                else
                {
                    animator.SetTrigger("jump");
                    _rigidbody.velocity = Vector2.up * (jumpForce - 3);
                }
                numOfJumps++;
            }
        }
        else
        {
            if (isGrounded)
            {
                animator.SetTrigger("jump");
                _rigidbody.velocity = Vector2.up * jumpForce;
            }
        }
    }
    public void WallJump()
    {
        if (upgrade)
        {
            if (wallSliding && wallJumps > 0)
            {
                _rigidbody.velocity = new Vector2(xWallForce * -horizontalSpeed, yWallForce);
                --wallJumps;
            }
        }
    }
    void Flip()
    {
        if (horizontalSpeed > 0 && transform.localScale.x < 0 || horizontalSpeed < 0 && transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1, 1);
            flipped = !flipped;
        }
    }
}
