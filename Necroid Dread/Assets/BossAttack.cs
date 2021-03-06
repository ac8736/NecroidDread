using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform gun;
    bool playerNear = false;
    public int detection = 10;
    public int shotLimit = 3;

    public AudioClip gunshot;
    AudioSource _audio;

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        StartCoroutine(Attack());
    }
    private void Update()
    {
        //print(transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y);
        //print(Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position));
        if (Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y) < 15)
        {
            if (Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y) < 10)
            {
                playerNear = true;
            }
            else
            {
                playerNear = false;
            }
            if (this.GetComponent<BossHealth>().currentHealth <= 20) {
                print("Boss Enraged!");
                shotLimit = 5;
            }
        }
        else
        {
            playerNear = false;
        }
    }
    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            if (playerNear)
            {
                for (int i = 0; i < shotLimit; i++) {
                    _audio.PlayOneShot(gunshot);
                    Instantiate(bullet, gun.position, gun.rotation);
                    yield return new WaitForSeconds(0.5f);
                }
            }
        }
    }
}
