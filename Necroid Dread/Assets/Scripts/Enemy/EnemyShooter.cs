using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = .02f;
    private int range = 8;
    private Vector2 sightDirection = Vector2.right;
    public float patrolSpeed;
    public Rigidbody2D _rigidbody;
    public Transform groundCheck;
    public Transform wallCheck;
    private bool noGround;
    private bool hitWall;
    public LayerMask platformLayer;
    public GameObject eyes;
    public GameObject gun;
    private bool foundPlayer = false;
    public Transform player;
    public GameObject bullet;
    private bool canShoot = true;
    public Animator animator;
    public int health = 3;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(eyes.transform.position, -sightDirection * range);
        if (hit.collider != null) {
            if (hit.transform.tag == "Player" || hit.transform.tag == "Bullet") {
                foundPlayer = true;
            } else {
                foundPlayer = false;
            }
        } else {
            foundPlayer = false;
        }
    }

    private void FixedUpdate() {
        if (foundPlayer) {
            animator.SetBool("seePlayer", true);
            Attack();
        } else {
            animator.SetBool("seePlayer", false);
            Patrol();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.collider.CompareTag("Player") && !other.collider.CompareTag("MonsterBullet")) {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            animator.SetTrigger("hit");
            health--;
            if (health <= 0)
                StartCoroutine(die());
        }
    }

    void Patrol() {
        noGround = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, platformLayer);
        hitWall = Physics2D.OverlapCircle(wallCheck.position, 0.1f, platformLayer);
        if (noGround || hitWall) {
            Flip();
        }
        Vector3 targetVelocity = new Vector2(patrolSpeed, _rigidbody.velocity.y);
       _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    void Attack() {
        _rigidbody.velocity = Vector2.zero;
        if (player.position.x < transform.position.x && transform.localScale.x < 0) {
            Flip();
        }
        else if (player.position.x > transform.position.x && transform.localScale.x > 0) {
            Flip();
        }
        if (canShoot) {
            print("shoot");
            Instantiate(bullet, gun.transform.position, Quaternion.identity);
            canShoot = false;
            StartCoroutine(shootCD());
        }
    }

    void Flip() {
        transform.localScale =  new Vector2(transform.localScale.x * -1, transform.localScale.y);
        patrolSpeed *= -1;
        sightDirection = -sightDirection;
    }

    IEnumerator shootCD() {
        yield return new WaitForSeconds(0.8f);
        canShoot = true;
        yield return null;
    }

    IEnumerator die() {
        animator.SetTrigger("die");
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}