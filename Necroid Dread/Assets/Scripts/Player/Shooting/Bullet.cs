using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        if (!playerMovement.flipped) {
            transform.localScale = new Vector3(-1, 1, 1);
            GetComponent<Rigidbody2D>().velocity = new Vector2(50, 0);
        } else {
            transform.localScale = new Vector3(1, 1, 1);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-50, 0);
        }
        StartCoroutine(DestroyBullet());
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Contains("Enemy")) {
            Destroy(gameObject);
        }
    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
