using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private bool canShoot = true;
    public GameObject bullet;
    public Transform gun;
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
