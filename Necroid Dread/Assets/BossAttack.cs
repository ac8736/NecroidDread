using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform gun;
    bool playerNear = false;
    public int detection = 10;

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
            if (Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y) < 50)
            {
                playerNear = true;
            }
            else
            {
                playerNear = false;
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
                 _audio.PlayOneShot(gunshot);
                Instantiate(bullet, gun.position, gun.rotation);
            }
        }
    }
}
