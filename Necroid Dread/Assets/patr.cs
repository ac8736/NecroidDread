using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patr : MonoBehaviour
{
    public int test = 10;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(test, rb.velocity.y);
    }
}
