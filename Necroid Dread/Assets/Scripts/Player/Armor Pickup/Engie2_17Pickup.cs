using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engie2_17Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.AddComponent<Engie2_17>();
            Destroy(gameObject);
        }
    }
}
