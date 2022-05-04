using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    void Start()
    {
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