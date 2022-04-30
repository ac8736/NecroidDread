using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (-GameObject.FindGameObjectWithTag("EnemyShooter").GetComponent<EnemyShooter>().transform.localScale.x == 1)
        {
            _rigidbody.velocity = new Vector2(30, 0);
        }
        else
        {
            _rigidbody.velocity = new Vector2(-30, 0);
        }
        StartCoroutine(despawn());
    }

    private void OnCollisionEnter2D(Collision2D other) {
        StopAllCoroutines();
        Destroy(this.gameObject);
    }

    IEnumerator despawn() {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        yield return null;
    }
}