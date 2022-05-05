using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryShooter : MonoBehaviour
{
    private int range = 10;
    private Vector2 sightDirection = Vector2.right;
    public GameObject eyes;
    public GameObject gun;
    private bool foundPlayer = false;
    public GameObject bullet;
    private bool canShoot = true;
    public Animator animator;
    public int health = 3;
    bool cantDmg = false;
    public bool facingLeft = false;
    void Update()
    {
        RaycastHit2D hit;
        if (facingLeft) {
            //Debug.DrawRay(eyes.transform.position, -sightDirection * range, Color.red);
            hit = Physics2D.Raycast(eyes.transform.position, -sightDirection * range);
        }
        else {
            //Debug.DrawRay(eyes.transform.position, sightDirection * range, Color.red);
            hit = Physics2D.Raycast(eyes.transform.position, sightDirection * range);
        }
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
            Attack();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            if (!cantDmg) {
                animator.SetTrigger("hit");
                health--;
                if (health <= 0)
                    StartCoroutine(die());
            }
        }
    }
    void Attack() {    
        if (canShoot) {
            GameObject newBullet = Instantiate(bullet, gun.transform.position, Quaternion.identity);
            if (facingLeft) 
                newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-30, 0);
            else 
                newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(30, 0);
            canShoot = false;
            StartCoroutine(shootCD());
        }
    }
    IEnumerator shootCD() {
        yield return new WaitForSeconds(0.8f);
        canShoot = true;
        yield return null;
    }
    IEnumerator die() {
        cantDmg = true;
        animator.SetTrigger("die");
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
