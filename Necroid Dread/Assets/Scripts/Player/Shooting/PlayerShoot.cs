using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public ShootDetection shootDetection;
    private bool canShoot = true;
    public GameObject bullet;
    public Transform gun;
    void Update()
    {
        if (shootDetection.shoot || Input.GetKeyDown(KeyCode.E)) {
            if (canShoot)
                Shoot();    
        }
    }
    void Shoot()
    {
        Instantiate(bullet, gun.position, Quaternion.identity);
        StartCoroutine(ShootCooldown());
    }
    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
}
