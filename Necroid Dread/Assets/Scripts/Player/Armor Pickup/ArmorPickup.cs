using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    public AudioClip PickupSound;
    AudioSource _audio;

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().animator.SetBool("UpgradedArmor", true);
            other.GetComponent<PlayerMovement>().upgrade = true;
            _audio.PlayOneShot(PickupSound);
            Destroy(this.gameObject);
        }
    }
}
