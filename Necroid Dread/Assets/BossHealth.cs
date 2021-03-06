using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public float currentHealth = 20;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("YouWon");
        }
    }
    void TakeDamage(float damage)
    {
        print("took dmg");
        currentHealth -= damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("collision");
        if (other.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger("hurt");
            TakeDamage(1);
        }
    }
}
