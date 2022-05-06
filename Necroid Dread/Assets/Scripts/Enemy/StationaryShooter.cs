using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryShooter : MonoBehaviour
{
    private float range = 0.1f;
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
        if (hit.collider != null && (!harmless)) {
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
                newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
            else 
                newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
            canShoot = false;
            StartCoroutine(shootCD());
        }
    }
    IEnumerator shootCD() {
        yield return new WaitForSeconds(1.5f);
        canShoot = true;
        yield return null;
    }
    IEnumerator die() {
        cantDmg = true;
        animator.SetTrigger("die");
        harmless = true;
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
