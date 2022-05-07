using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryShooter : MonoBehaviour
{
    private float range = 14f;
    private Vector2 sightDirection = Vector2.right;
    public GameObject eyes;
    public GameObject gun;
    private bool foundPlayer = false;
    public GameObject bullet;
    private bool canShoot = true;
    private bool harmless = false;
    public Animator animator;
    public int health = 4;
    bool cantDmg = false;
    public bool facingLeft = false;

    public AudioClip DeathSound;
    public AudioClip Gunshot;
    AudioSource _audio;

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        RaycastHit2D hit;
        if (facingLeft)
        {
            Debug.DrawRay(eyes.transform.position, -sightDirection, Color.red);
            hit = Physics2D.Raycast(eyes.transform.position, -sightDirection, range);
        }
        else
        {
            //Debug.DrawRay(eyes.transform.position, sightDirection * range, Color.red);
            hit = Physics2D.Raycast(eyes.transform.position, sightDirection, range);
        }
        if (hit.collider != null && (!harmless))
        {
            //print(hit.collider.transform.tag);
            if (hit.transform.tag == "Player" || hit.transform.tag == "Bullet")
            {
                foundPlayer = true;
            }
            else
            {
                foundPlayer = false;
            }
        }
        else
        {
            foundPlayer = false;
        }
    }
    private void FixedUpdate()
    {
        if (foundPlayer)
        {
            Attack();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (!cantDmg)
            {
                animator.SetTrigger("hit");
                health--;
                if (health <= 0)
                    StartCoroutine(die());
            }
        }
    }
    void Attack()
    {
        if (canShoot)
        {
            GameObject newBullet = Instantiate(bullet, gun.transform.position, Quaternion.identity);
            if (facingLeft)
                newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-6, 0);
            else
                newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(6, 0);
            canShoot = false;
            StartCoroutine(shootCD());
        }
    }
    IEnumerator shootCD()
    {
        _audio.PlayOneShot(Gunshot);
        yield return new WaitForSeconds(1.5f);
        canShoot = true;
        yield return null;
    }
    IEnumerator die()
    {
        _audio.PlayOneShot(DeathSound, 0.5f);
        cantDmg = true;
        animator.SetTrigger("die");
        animator.SetTrigger("fade");
        harmless = true;
        gameObject.tag = "Dead";
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
