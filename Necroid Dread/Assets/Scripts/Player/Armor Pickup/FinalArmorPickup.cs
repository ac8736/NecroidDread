using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalArmorPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print("Armor Pickup");
            other.GetComponent<PlayerMovement>().animator.SetBool("FinalArmor", true);
            Destroy(gameObject);
        }
    }
}
