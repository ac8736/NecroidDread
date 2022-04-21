using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public Transform feet;
    public Image joystick;
    bool movingLeft, movingRight, isJumping, isCrouching = false;
    public float runSpeed = 20f;
    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = .02f;
    private Rigidbody2D _rigidbody;
    public float jumpForce = 10f;
    bool isGrounded = true;
    float checkRadius = 0.2f;
    public float crouchSpeedReduction = 0.5f;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movingLeft = joystick.GetComponent<Joystick>().movingLeft;
        movingRight = joystick.GetComponent<Joystick>().movingRight;
        isJumping = joystick.GetComponent<Joystick>().isJumping;
        isCrouching = joystick.GetComponent<Joystick>().isCrouching;
        isGrounded = Physics2D.OverlapCircle(feet.position, checkRadius, platformLayerMask);
    }

    private void FixedUpdate()
    {
        if (movingLeft && !isCrouching)
        {
            Vector3 targetVelocity = new Vector2(runSpeed, _rigidbody.velocity.y);
            _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        if (movingRight && !isCrouching)
        {
            Vector3 targetVelocity = new Vector2(-runSpeed, _rigidbody.velocity.y);
            _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        if (movingLeft && isCrouching)
        {
            print("crouchwalking");
            Vector3 targetVelocity = new Vector2(runSpeed * crouchSpeedReduction, _rigidbody.velocity.y);
            _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        if (movingRight && isCrouching)
        {
            print("crouchwalking");
            Vector3 targetVelocity = new Vector2(-runSpeed * crouchSpeedReduction, _rigidbody.velocity.y);
            _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        if (!movingRight && !movingLeft)
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        if (isJumping && isGrounded)
        {
            _rigidbody.velocity = Vector2.up * jumpForce;
        }

        if (isCrouching && isGrounded)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
