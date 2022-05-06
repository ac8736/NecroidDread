using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().animator.SetBool("UpgradedArmor", true);
            other.GetComponent<PlayerMovement>().upgrade = true;
            Destroy(this.gameObject);
        }
    }
}
