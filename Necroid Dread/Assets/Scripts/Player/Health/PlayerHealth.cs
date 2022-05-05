using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 20;
    public float maxShield = 30;
    public float currentShield;
    public float currentHealth;
    public Healthbar healthbar;
    public Healthbar shieldbar;
    public GameObject shieldUI;
    bool shieldActive = false;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("MonsterBullet")) {
            TakeDamage(5);
        }
    }
    void TakeDamage(float damage) {
        if (shieldActive && currentShield > 0) {
            currentShield -= damage;
            shieldbar.SetHealth(currentShield);
            StopAllCoroutines();
            StartCoroutine(initializeShieldRegeneration());
        } else {
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);
        }
    }
    public void obtainShield() {
        shieldActive = true;
        currentShield = maxShield;
        shieldbar.SetMaxHealth(maxShield);
        shieldUI.SetActive(true);
    }
    IEnumerator initializeShieldRegeneration() {
        yield return new WaitForSeconds(5);
        StartCoroutine(regenerateShield());
    }
    IEnumerator regenerateShield() {
        while (currentShield < maxShield) {
            if (currentShield + 0.1f <= maxShield) {
                currentShield += 0.1f;
                shieldbar.SetHealth(currentShield);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
