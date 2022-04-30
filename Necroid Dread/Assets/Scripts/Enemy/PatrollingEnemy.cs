using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatrollingEnemy : MonoBehaviour
{
    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = .02f;
    public float patrolSpeed;
    public Rigidbody2D _rigidbody;
    public Transform groundCheck;
    public Transform wallCheck;
    private bool noGround;
    private bool hitWall;
    public LayerMask platformLayer;
    //public AudioClip deathSound;
    //AudioSource _audioSource;
    public Animator animator;

    private void Start() {
        //_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        noGround = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, platformLayer);
        hitWall = Physics2D.OverlapCircle(wallCheck.position, 0.1f, platformLayer);
    }

    private void FixedUpdate() {
        Patrol();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            animator.SetTrigger("die");
            StartCoroutine(kill());
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.collider.CompareTag("Player")) {
            Flip();
        } else if (other.gameObject.CompareTag("Player")){

        }
    }

    void Patrol() {
        if (noGround || hitWall) {
            Flip();
        }
        Vector3 targetVelocity = new Vector2(patrolSpeed, _rigidbody.velocity.y);
       _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }
    void Flip() {
        transform.localScale =  new Vector2(transform.localScale.x * -1, transform.localScale.y);
        patrolSpeed *= -1;
    }

    IEnumerator kill() {
        //_audioSource.PlayOneShot(deathSound);
        animator.SetTrigger("die");
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
        yield return null;
    }
}