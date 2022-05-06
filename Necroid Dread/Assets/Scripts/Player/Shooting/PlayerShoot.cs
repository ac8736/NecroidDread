using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private bool canShoot = true;
    public GameObject bullet;
    public Transform gun;
    public AudioClip bulletSound;
    AudioSource _audio;
    void Awake() {
        _audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (canShoot)
                Shoot();
                 
        }
    }
    public void Shoot()
    {
        if (canShoot)
        {
            _audio.PlayOneShot(bulletSound);  
            Instantiate(bullet, gun.position, Quaternion.identity);
            StartCoroutine(ShootCooldown());
        }
    }
    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.1f);
        canShoot = true;
    }
}
